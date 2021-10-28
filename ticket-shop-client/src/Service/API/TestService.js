import axios from "axios";
import BaseService from "./BaseService";
class TestService extends BaseService{
    constructor() {
        super();
        this.url+="/api/test"
    }

    async Post() {
        let url = this.url+"/post"
        return await super.Post(url);
    }

    async Get() {
        let url = this.url+"/number"
        return await super.Get(url);
    }
}

export default TestService;