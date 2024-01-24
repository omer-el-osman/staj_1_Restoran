// -- put your code here
let menu = document.querySelector("#bur-menu");
let menuState = false;

menu.addEventListener("click", () => {
  let navBar = document.querySelector(".navbar");

  if (!menuState) {
    console.log("hello ");
    navBar.style.display = "block";
    console.log("icerdeyim");
    menuState = !menuState;
  } else {
    navBar.style.display = "none";
    console.log("burada");

    menuState = !menuState;
  }
});
// ? element.classList.contains("class-name") i will use
// document query selectoall grap all element that have a particular class queryselcetor only grap the first one
// ! onemli bir kisim burada calisiyorum 
let observer = new IntersectionObserver((entries) => {
  // class take callback function as constructur
  // can observe multiple elements at the same time
  //this function will run any time the visibility  of one of the observed elemets has been changes because it handle multiple  we need to use foreach  to loop over them
  // that call observe
  console.log(entries)
  entries.forEach((entry) => {
    if (entry.isIntersecting) {
      entry.target.classList.add("show");
    }
    // } else {
      // so we don't show the animation over and over again
    //   entry.target.classList.remove("show");
    // }
  });
});



// menu

// ["","",""],




let listen = (doc) => {
  return {
    on: (type, selector, callback) => {
      // let elem=doc.querySelectorAll(selector)
      doc.addEventListener(type, (event) => {
        // console.log(event.target.id + "yukardaki");
        if (
          event.target.id == "sushi" ||
          event.target.id == "sashimi" ||
          event.target.id == "maki"
        ) {
          callback(event.target.id);
        } else {
          console.log("bir hata olustu tekrar deneyiniz ");
          return;
        }
      });
    },
  };
};
//buradan omer bunu comment yap
//listen(document).on("click", ".menu-tab", addItemToMenu);
//let menuPage = document.querySelector(".yemek-menu-container");
//// menuPage.classList.add("hidden")
//// TODO: make hidden adding every time you click on a categori 
//function addItemToMenu(id) {
//  // sen burada get islemi yapacaksin ve obj yerinde cektigin veri koyacaksin
//  console.log(id);
//  menuPage.innerHTML = "";
//  let obj = {
//    // burada ayni sey yapip veritabanindan cekecegiz burada olusturmaktansa

//    sushi: [
//      [
//        "	Horse mackerel MackerelHerring yemek adi",
//        "./painting-sushi-plate-with-picture-fish-it.jpg",
//        "$8.00 fiyat",
//      ],
//      ["Tuna Salmon Shrimp Sea bream Sea bass", "", "$8.50"],
//      ["Squid Octopus Sweet shrimp Bonite Swordfish", "", "$8.50"],
//      ["Salmon roe Flounder Scallop TOBIKO", "", "$9.50"],
//      ["Fatty tuna Grilled eel", "", "$10.50"],
//      ["Sea Urchin (1 piece)", "", "$10"],
//    ],
//    maki: [
//      ["TEKKA MAKI (tuna)", "", "$8.00"],
//      ["	SHAKE MAKI (salmon)", "", "$8.00"],
//      ["SALMON AVOCADO MAKI", "", "$8.00"],
//      ["	KANI AVOCADO MAKI", "", "$9.50"],
//      ["	AVOCADO MAKI", "", "$7.00"],
//      ["	SPICY TUNA AVOCADO MAKI", "", "$10.50"],
//      ["	SPICY TUNA MAKI", "", "$9.50"],
//      ["	SHAKE KAWA MAKI", "", "$9.50"],
//      ["	IKURA MAKI", "", "$10.00"],
//      ["	EBITEN MAKI", "", "$10.50"],
//    ],
//    sashimi: [
//      ["	TAI SASHIMI", "", "$17.50"],
//      ["	HIRAME USUZUKURI", "", "$17.00"],
//      ["KATSUO SASHIMI", "", "$17.00"],
//      ["	TAKO SASHIMI", "", "$17.00"],
//      ["	SHAKE MAGURO SASHIMI", "", "$24.00"],
//      ["	HOTATE SASHIMI", "", "$14.50"],
//      ["	SHAKE TATAKI", "", "$14.50"],
//      ["	AJI TATAKI", "", "$	13.00"],
//    ],
//  };

//  obj[id].forEach((elem) => {
//    console.log("fore each girdim");
//    let yemekCarti = document.createElement("div");
//    yemekCarti.classList.add("yemek-carti");
    

//    let yemekImgCon = document.createElement("div");
//    yemekImgCon.classList.add("yemek-img-con");
//    let img = document.createElement("img");
//    img.src = elem[1];
//    img.classList.add("yemek-img");
//    yemekImgCon.appendChild(img);

//    yemekCarti.appendChild(yemekImgCon);

//    let textElem = document.createElement("p");
//    let text = document.createTextNode(elem[0].trim());
//    textElem.appendChild(text);
//    console.log("buraya kadar geldim ");
//    yemekCarti.appendChild(textElem);
//    let spanElem = document.createElement("span");
//    spanElem.classList.add("price");
//    let spanTxt = document.createTextNode(elem[2]);
//    spanElem.appendChild(spanTxt);
//    yemekCarti.appendChild(spanElem);
//    console.log("calisioooom");
//    menuPage.appendChild(yemekCarti);
    
//  });
 
//}


let hiddenElements = document.querySelectorAll(".hidden");
hiddenElements.forEach(elem=>observer.observe(elem))

//let radiobtn = document.querySelectorAll(".table");
//console.log(radiobtn);

// https://www.tutorialspoint.com/how-to-clear-all-div-s-content-inside-a-parent-div-in-javascript#:~:text=Using%20the%20innerHTML%20property%20of%20the%20HTML%20element&text=We%20can%20access%20the%20element,elements%20inside%20a%20parent%20div.

// https://stackoverflow.com/questions/4825295/onclick-to-get-the-id-of-the-clicked-button

// https://www.tutorialspoint.com/how-to-clear-all-div-s-content-inside-a-parent-div-in-javascript#:~:text=Using%20the%20innerHTML%20property%20of%20the%20HTML%20element&text=We%20can%20access%20the%20element,elements%20inside%20a%20parent%20div.
