import {objectResult} from "../Api/GetResults";
import React from "react";
import '../СSS/RenderSearchResults.css';

const RenderSearchResults = ({
                                 results,
                                 stateUpdatingCallback
                             }: {
    results: objectResult[];
    stateUpdatingCallback: (selected: objectResult) => void;
}) => {
    if (results.length) {
        return (
            <div className='resultsBlock bg-light'>
                {results.map((result: objectResult) => {
                    return (
                        <div key={result.id} className='resultsBlockLink'
                          onClick={() => {
                            stateUpdatingCallback( {id: result.id, title: result.title, description: result.description})
                        }}>
                            <p className='text-center resultsLink'>{result.title}</p>
                       </div>
                    );
                })}
            </div>
        );
    }
    else{
        return <></>
    }
};
export default RenderSearchResults;