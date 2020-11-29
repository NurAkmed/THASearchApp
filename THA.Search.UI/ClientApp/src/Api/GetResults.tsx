import axios from "axios";

export interface objectResult {
    id: number;
    title: string;
    description: string;
}
async function getResults(query: string){
    try {
        const response = await axios.get<objectResult[]>('http://localhost:85/api/search/' + query);
        return response.data;
    } catch (e) {
        return [];
    }
}
export default getResults;