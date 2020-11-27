import axios from "axios";


async function ResultsList(search: string){
    try {
        const a = await axios.get('http://localhost:85/api/search/' + search);
        return a.data;
    } catch (e) {
        return [];
    }

}
export default ResultsList;