// add pageTitle
let pageTitle = "My Shopping List";
// add groceries
let groceries = ["Eggs" , "Milk", "Bread", "Chips", "Flour", "Baking Soda", "Cheese", "Meat", "Pasta", "Tortilla"]
/**
 * This function will get a reference to the title and set its text to the value
 * of the pageTitle variable that was set above.
 */
function setPageTitle() {
  document.getElementById("title").innerText = pageTitle;
}

/**
 * This function will loop over the array of groceries that was set above and add them to the DOM.
 */
function displayGroceries() {

  for(let item of groceries){
    let list = document.createElement("LI");
    let itemInList = document.createTextNode(item);
    list.appendChild(itemInList);

    document.getElementById("groceries").appendChild(list);
  }
    
  
}

/**
 * This function will be called when the button is clicked. You will need to get a reference
 * to every list item and add the class completed to each one
 */
function markCompleted() {
  for(let item of document.getElementsByTagName("li")){
    item.className += "completed"
  }
}

setPageTitle();

displayGroceries();

// Don't worry too much about what is going on here, we will cover this when we discuss events.
document.addEventListener('DOMContentLoaded', () => {
  // When the DOM Content has loaded attach a click listener to the button
  const button = document.querySelector('.btn');
  button.addEventListener('click', markCompleted);
});
