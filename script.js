// Write your JavaScript here.
import { itemFetch, categoryFetch, categoryFetchById, restaurantFetch } from "./dataServices.js"

//header elements
const resInfo = document.getElementById("restaurant-info");
const resName = document.getElementById("restaurant-name");
const resTagline = document.getElementById("tagline");

//Category nav elements
const cateNav = document.getElementById("category-nav");

//Menu elements
const wholeMenu = document.getElementById("menu");
const menuStatus = document.getElementById("status");
const bootUpGrid = document.getElementById("boot-up-grid"); 
const mainFunctions = document.getElementById("main-functions"); 
const sweetSyntax = document.getElementById("sweet-syntax"); 
const fuel = document.getElementById("fuel"); 

//-------------functions

//Item functions
const showItem = async () => {
try{
    const items = await itemFetch();
    const categories = await categoryFetch(); 
    
        categories.forEach(async (category) =>{ 
           const categoryHeader = document.createElement("div");
            const categoryName = document.createElement("h3");
            const categoryNum = document.createElement("h3");
            categoryName.textContent = category.name; 
            categoryNum.textContent = category.num;

            categoryHeader.appendChild(categoryName); 
            categoryHeader.appendChild(categoryNum); 
            categoryHeader.className = "flex p-2 text-3xl lg:text-5xl mt-3 font-bold";
             wholeMenu.appendChild(categoryHeader);
        }); 
         
    items.forEach(async (item) => {
         
       
        const itemDiv = document.createElement("div");
        const imgDiv = document.createElement("div"); 
        const desDiv = document.createElement("div"); 
        const tagDiv = document.createElement("div"); 

        const itemName = document.createElement("p");
        itemName.textContent = item.name;
      
       
        const itemPrice = document.createElement("p");
        itemPrice.textContent = `$${item.price}.00`;
        itemPrice.className = "text-orange-700"
        
        const itemDescription = document.createElement("p");
        itemDescription.textContent = item.description;
       
        const itemTag = document.createElement("a");
        itemTag.textContent = item.tag; 
        
        const itemImg = document.createElement("img");
        itemImg.src = item.image_url; 
        itemImg.alt = item.description;
        itemImg.className = "w-fit lg:max-w-[27rem] mx-auto p-4"; 
    
    
        imgDiv.appendChild(itemImg); 
      
    itemDiv.appendChild(itemName);
          

        itemDiv.appendChild(itemPrice);
        desDiv.appendChild(itemDescription);
        tagDiv.appendChild(itemTag);
       const square = document.createElement("div")
         square.appendChild(imgDiv); 
            
            square.appendChild(itemDiv); 
           square.appendChild(desDiv); 
             square.appendChild(tagDiv); 

        itemDiv.className = "flex flex-wrap justify-between p-2 font-semibold text-2xl";
        desDiv.className = "flex flex-wrap justify-between p-2 text-stone-600"; 
        tagDiv.className="border border-slate-700 p-2 rounded-3xl font-semibold w-fit bg-stone-200 text-stone-600"; 
       
        if(item.category_id === 1){
           categoryHeader.appendChild(square); 
           
        }
        if(item.category_id === 2){
           mainFunctions.appendChild(square); 
            
        
        }
         if(item.category_id === 3){
            sweetSyntax.appendChild(square); 
        
        }
          if(item.category_id === 4){
            fuel.appendChild(square); 
         
        }

        menuStatus.textContent = "";
    
    });
}catch{
  menuStatus.textContent = "Could not load Items. Check the console. ";
        console.log(error); 
}



}



const showCategory = async () => {
    try{
        const categories = await categoryFetch(); 
    categories.forEach((category) => {
        const categoryName = document.createElement("a");
        categoryName.textContent = category.name;
        categoryName.className = "border border-slate-700 p-2 rounded-3xl font-semibold";
        cateNav.appendChild(categoryName);
    });
}catch(error){
      menuStatus.textContent = "Could not load Categories. Check the console. ";
        console.log(error); 
}
}


//Restuarant functions
const showRestaurant = async () => {
    try {
        const data = await restaurantFetch();
        const info = document.createElement("p");

        info.textContent = `${data[0].address}`

        const hours = document.createElement("p");
        hours.textContent = ` ${data[0].hours}`;

        const phone = document.createElement("p");
        phone.textContent = `${data[0].phone}`

        resInfo.appendChild(info);
        resInfo.appendChild(hours);
        resInfo.appendChild(phone);
        const longName = data[0].name.toUpperCase().split(" ");
        const n1 = document.createElement("h1");
        const n2 = document.createElement("h1");
        n1.textContent = `${longName[0]}`;
        n2.textContent = `${longName[1]}`;
        resName.appendChild(n1);
        resName.appendChild(n2);
        resTagline.textContent = `${data[0].tagline}`
    } catch (error) {
         menuStatus.textContent = "Could not load Restaurant Info. Check the console. ";
        console.log(error); 
    }


}



//---------------listeners

//--------------On load
showRestaurant();
showCategory(); 
showItem(); 