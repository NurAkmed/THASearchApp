import React from 'react';
import {objectResult} from "../Api/GetSearch";
import getResults from "../Api/GetSearch";
import RenderSearchResults from "./RenderSearchResults";
import '../СSS/Search.css';
import {Input} from "reactstrap/es";
import RenderResultDescription from "./RenderResultDescription";

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
                if(response.length === 0){
                    error = 'Нет результатов';
                }
                this.setState({results: response, message: error});
    };

    inputChange = async (event: any) => {
        const query = await event.target.value;
        if ( ! query ) {
            this.setState({ query, results: [], message: '' } );
        }
        else if(query.length < 3){
            this.setState({ query, results: [], message: 'Минимум три символа' } );
        }
        else {
            this.setState({ query, message: '' }, () => {
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
        const { query } = this.state;
        return (
            <div>
            <div className='searchBlock'>
                <div className="p-1 bg-light rounded rounded-pill shadow-sm mt-4">
                    <div className="input-group">
                        <Input type="search" value={query}
                               placeholder="Что ищем?"
                               className="form-control border-0 bg-light"
                               onChange={this.inputChange}
                        />
                    </div>
                </div>
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