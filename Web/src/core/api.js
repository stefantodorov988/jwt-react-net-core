import _ from "lodash"
import { conf } from "./conf"
import axios from "axios"

export class Api {
  constructor() {
    this.conf = conf;
  }

  send(method, url, data, headers, options) {
    // set default options
    options = _.assign({ error: true, getAll: false, ajax: {} }, options || {});
    data = data || {};
    headers = headers ? headers : {};
    headers = _.assign({}, this.conf.defaultHeaders, headers);
    headers.clientId = conf.clientID;
    
    if (localStorage.currentUser)  { // authorizing user 
      headers.Authorization = 'Bearer ' + JSON.parse(localStorage.currentUser).token;
    }
    return axios({
      url: this.url(url),
      method,
      headers,
      data,
      ...options.ajax
    }).then(
      res => {
        return _.get(options, "getAll") ? res : res.data;
      },
      err => {
        if (_.get(options, "error")) {
          this.handleErrors(err);
        }
        return err;
      }
    );
  }

  url(url) {
    return this.conf.server + url;
  }

  get(url, query, headers, options) {
    return this.send('get', url, query, headers, options);
  }

  post(url, data, headers, options) {
    return this.send("post", url, data, headers, options);
  }

  put(url, data, headers, options) {
    return this.send("put", url, data, headers, options);
  }

  patch(url, data, headers, options) {
    return this.send("patch", url, data, headers, options);
  }

  remove(url, headers, options) {
    return this.send("delete", url, {}, headers, options);
  }

  upload(url, file, headers) {}

  download(url) {}

  // default error handler
  handleErrors(err) {
    // set the default error message if the server is not providing one
    const msg = _.get(err, "response.message") || "Server error";

    if (err.response.status !== 401) {
      console.log(msg);
    } else {
      console.log("Your session has expired");
    }
  }
}

export default new Api();