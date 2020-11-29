import React from "react";
import {objectResult} from "../Api/GetResults";


const RenderResultDescription = (result: objectResult) => {
  return(
      <div key={result.id}>
          <h3 className='text-center'>{result.title}</h3>
          <p>{result.description}</p>
      </div>
  )
};
export default RenderResultDescription;