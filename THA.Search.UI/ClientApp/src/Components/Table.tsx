import React from "react";
import {Table} from "reactstrap/es";

interface objectResult {
    id: number;
    title: string;
    description: string;
}

const TableRes = (props: any) => {
    if(props.results.length !== 0){
         let tableResults = props.results.map((result: objectResult) => {
            return (
                <tr key={result.id}>
                    <td>{result.id}</td>
                    <td>{result.title}</td>
                    <td>{result.description}</td>
                </tr>
            )
        });
        return (
            <Table>
                <thead>
                <tr>
                    <th>#</th>
                    <th>Название</th>
                    <th>Описание</th>
                </tr>
                </thead>
                <tbody>
                {tableResults}
                </tbody>
            </Table>
        );
    }
    else{
        return (
            <p className="danger">Нет результатов</p>
        );
    }
}
export default TableRes;
