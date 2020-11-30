import React from "react";
import {Input} from "reactstrap/es";


const SearchInput = ({
                         query,
                         inputChange,
                         onPressingEnter
                     }: {
    query: string;
    inputChange: (event: any) => void;
    onPressingEnter: (event: any) => void;
}) => {
    return(
        <div className="p-1 bg-light rounded rounded-pill shadow-sm mt-4">
            <div className="input-group">
                <Input type="search" value={query}
                       placeholder="Что ищем?"
                       className="form-control border-0 bg-light"
                       onChange={inputChange}
                       onKeyDown={onPressingEnter}
                />
            </div>
        </div>
    )
}
export default SearchInput;