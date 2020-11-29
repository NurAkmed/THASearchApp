import React from "react";
import {objectResult} from "../Api/GetResults";


const RenderResultDescription = ({
                                     result,
                                     removeItem}
                                     :
                                     {
                                         result: objectResult,
                                         removeItem: (res: objectResult) => void}
                                         ) => {
  return(
      <div key={result.id}>
          <h3 className='text-center'>{result.title}</h3>
          <p>{result.description}
          <button type="button" className="close" aria-label="Close" onClick={() => {removeItem({id: result.id, title: result.title, description: result.description})}}>
              <span aria-hidden="true">&times;</span>
          </button>
          </p>
      </div>
  )
};
export default RenderResultDescription;