const baseUrl =  "http://localhost:5198/api/"; 

export const itemFetch = async () => {

    const response = await fetch(baseUrl + "item");
    if (!response.ok) {
        throw new Error(`GET failed: ${response.status}`);
    }

    const data = await response.json();

    // console.log(data); 


    return data;



}

export const categoryFetchById = async (id) => {

    const response = await fetch(baseUrl + "category/" + id);
    if (!response.ok) {
        throw new Error(`GET failed: ${response.status}`);
    }
    const data = await response.json();
    return data;


}

export const categoryFetch = async () => {

    const response = await fetch(baseUrl + "category");
    if (!response.ok) {
        throw new Error(`GET failed: ${response.status}`);
    }
    const data = await response.json();
    // console.log(data); 

    return data;

    //console.log(error); 

}

export const restaurantFetch = async () => {

    const response = await fetch(baseUrl + "restaurant");
    if (!response.ok) {
        throw new Error(`GET failed: ${response.status}`);
    }
    const data = await response.json();
    return data;
    //  console.log(data); 



}