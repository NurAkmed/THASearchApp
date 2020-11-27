import React, {Component} from 'react';
import ResultsList from "../Api/GetSearch";
import {Button, FormGroup, Input, Table} from "reactstrap/es";
import TableRes from "./Table";


class SearchPage extends Component {

    state = {
         search: "",
        error: "",
        results: [],
        }

        async sendQuery(event: any){
        let searchWord = this.state.search;
        if(searchWord.length < 3) {
            event.preventDefault();
            await this.setState({error: 'Entered value cannot be less than three symbols'});
        }
        else {
                let a = await ResultsList(searchWord);
                await this.setState({search: '', error: '', results: a});
        }
}
    render() {
        return (
            <div>
                <FormGroup>
                    <Input className="w-25 mt-3" type="text" value={this.state.search}
                           onChange={(e) => {
                               let search = e.target.value;
                               this.setState({search});
                           }}/>
                </FormGroup>
                <p className="danger">{this.state.error}</p>
                <Button className="mb-2" color="primary" onClick={this.sendQuery.bind(this)}>Найти</Button>

              <TableRes results={this.state.results}/>

            </div>
        );
    }
}
export default SearchPage;