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
        selected: objectResult[]
}
class Search extends React.Component<any, IState> {
    state = {
            results: [],
            query: '',
            message: '',
            selected: []
    }

    getSearchResults = async (query: string) => {
        let response = await getResults(query);
        let error = '';
                if(!response.length){
                    error = 'Нет результатов';
                }
                this.setState({results: response, message: error});
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
                    <RenderResultDescription key={result.id} id={result.id} title={result.title} description={result.description} />
                );
            })
        return (
            <div>
              <div className='searchBlock'>
                  <SearchInput query={this.state.query} inputChange={this.inputChange} />
                <div>
                  <RenderSearchResults results={this.state.results}
                                    stateUpdatingCallback={(selectedObject: objectResult) =>
                                    {this.setState(state =>
                                      {
                                        const selected = state.selected.some(val=> selectedObject.title === val.title)
                                            ? state.selected
                                            : state.selected.concat(selectedObject);
                                        return {
                                            selected,
                                            query: '',
                                            results: []
                                        };
                                      });
                                    }}
                  />
                   <p className='text-center text-danger'>{this.state.message}</p>
                </div>
              </div>
                {resultDescription}
            </div>
        )
    }
}
export default Search;