import React from 'react';
import {objectResult} from "../Api/GetResults";
import getResults from "../Api/GetResults";
import RenderSearchResults from "./RenderSearchResults";
import '../СSS/Search.css';
import RenderResultDescription from "./RenderResultDescription";
import SearchInput from "./SearchInput";

interface IState {
    results: objectResult[],
        query: string,
        message: string,
        selected: objectResult[],
}
class Search extends React.Component<any, IState> {
    state = {
            results: [],
            query: '',
            message: '',
            selected: [],
    }

    getSearchResults = async (query: string) => {
        let response = await getResults(query);
        let error = '';
                if(response){
                    this.setState({results: response, message: error});
                }
    };

    displayResult = (sel: objectResult) =>
    {this.setState(state =>
     {
        const selected = state.selected.some(val=> sel.title === val.title)
            ? state.selected
            : state.selected.concat(sel);
        return {
            selected,
            query: '',
            results: []
        };
     });
    }
    onPressingEnter = (event: any) => {
        if (event.key === 'Enter') {
            this.setState(state =>
            {
                const selected = !state.results.some(item => item.title.includes(event.target.value))
                    ? this.state.selected
                    : state.results.filter(item => item.title.includes(event.target.value))

                return {
                    selected,
                    query: '',
                    results: []
                };
            });
        }
    }
    removeResult = (sel: objectResult) =>
        {this.setState(state =>
          {
              const selected = state.selected.filter(item => item.title !== sel.title)
            return {
                selected,
                query: '',
                results: []
            };
          });
        };

    inputChange = async (event: any) => {
        const query = await event.target.value;
        if (!query) {
            this.setState({query, results: [], message: ''});
        }
        else if(query.length < 3){
            this.setState({query, results: [], message: 'Минимум три символа'});
        }
        else {
            this.setState({query, message: ''}, () => {
                this.getSearchResults(query);
            });
        }
    };

    render() {
        let resultDescription = this.state.selected.map((result: objectResult) => {
                return (
                    <RenderResultDescription key={result.id} result={result} removeItem={(s: objectResult) => this.removeResult(s)} />
                );
            })
        return (
            <div>
              <div className='searchBlock'>
                  <SearchInput query = {this.state.query} inputChange = {this.inputChange} onPressingEnter = {this.onPressingEnter}/>
                <div>
                  <RenderSearchResults results={this.state.results}
                                       stateUpdatingCallback = {(obj: objectResult) => this.displayResult(obj)} />

                   <p className='text-center text-danger'>{this.state.message}</p>
                </div>
              </div>
                {resultDescription}
            </div>
        )
    }
}
export default Search;