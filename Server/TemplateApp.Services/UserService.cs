using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TemplateApp.Data.Models;
using TemplateApp.Repositories.Contract;
using TemplateApp.Services.Contract;
using TemplateApp.Services.Helpers;

namespace TemplateApp.Services
{
    public class UserService : IUserService
    {
        private readonly HashAlgorithm algorithm;
        private readonly AppSettings _appSettings;
        private readonly IRepository<User> userRepository;

        public UserService(IOptions<AppSettings> appSettings, IRepository<User> userRepository)
        {
            _appSettings = appSettings.Value;
            this.userRepository = userRepository;
            algorithm = SHA256.Create();
        }

        public User Authenticate(string username, string password)
        {
            string passwordHash = Encoding.Default.GetString(algorithm.ComputeHash(Encoding.UTF8.GetBytes(password)));
            Func<User, bool> filter = x => x.Password == passwordHash && x.Username == username;
            var user = this.userRepository.Filter(filter).ToList().FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);


            // remove password before returning
            user.Password = null;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            return this.userRepository.Filter().ToList();
        }

        public void Register(User user)
        {
            var bytearr = algorithm.ComputeHash(Encoding.UTF8.GetBytes(user.Password));
            var passwordHash = Encoding.Default.GetString(bytearr);


            Func<User, bool> uniqueValidation = x => x.Username == user.Username || x.Email == user.Email;
            if (userRepository.Filter(uniqueValidation).Any())
            {
               throw new ArgumentException("Email or username already taken");
            }

            user.Password = passwordHash;
            userRepository.Create(user);
            userRepository.SaveChanges();
        }
    }
}
