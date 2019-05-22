import { BehaviorSubject } from 'rxjs';

const currentUserSubject = new BehaviorSubject(JSON.parse(localStorage.getItem('currentUser')));

export const authenticationService = {
    login,
    logout,
    currentUser: currentUserSubject.asObservable(),
    get currentUserValue () { return currentUserSubject.value }
};

function login(username, password) {
    return window.api.post("/users/authenticate", { username: username, password: password })
        .then(user => {
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            if(user.token){
                localStorage.setItem('currentUser', JSON.stringify(user));
                currentUserSubject.next(user);
            }
            return user;

        }).catch(err =>{
            localStorage.clear()
        });
}

function logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
    currentUserSubject.next(null);
}
