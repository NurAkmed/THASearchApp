import axios from "axios";

export interface objectResult {
    id: number;
    title: string;
    description: string;
}
async function getResults(query: string){
    try {
        let URL = 'http://localhost:85/api/search/';
        const response = await axios.get<objectResult[] | undefined>(URL + query);
        return response.data;
    } catch (e) {
        console.log(e);
        return [];
    }
}
export default getResults;