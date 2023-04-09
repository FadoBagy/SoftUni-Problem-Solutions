function solve() {
  const tableBody = document.querySelector('.table tbody');
  const generateBtnEl = document.querySelectorAll('#exercise button')[0];
  const buyBtnEl = document.querySelectorAll('#exercise button')[1];
  const resultArea = document.querySelectorAll('#exercise textarea')[1];

  generateBtnEl.addEventListener('click', () => {
    const itemData = document.querySelectorAll('#exercise textarea')[0];
    try {
      const itemDataObjects = JSON.parse(itemData.value);

      for (let i = 0; i < itemDataObjects.length; i++) {
        if (
          itemDataObjects[i].img &&
          itemDataObjects[i].name &&
          itemDataObjects[i].price &&
          itemDataObjects[i].decFactor
        ) {
          let newRow = document.createElement('tr');

          let itemImg = document.createElement('td');
          let image = document.createElement('img');
          image.src = itemDataObjects[i].img;
          itemImg.appendChild(image);

          let itemName = document.createElement('td');
          let nameP = document.createElement('p');
          nameP.textContent = itemDataObjects[i].name;
          itemName.appendChild(nameP);

          let itemPrice = document.createElement('td');
          let priceP = document.createElement('p');
          priceP.textContent = itemDataObjects[i].price;
          itemPrice.appendChild(priceP);

          let itemFactor = document.createElement('td');
          let factorP = document.createElement('p');
          factorP.textContent = itemDataObjects[i].decFactor;
          itemFactor.appendChild(factorP);

          let checkBoxTd = document.createElement('td');
          let checkBox = document.createElement('input');
          checkBox.type = 'checkbox';
          checkBoxTd.appendChild(checkBox);

          newRow.appendChild(itemImg);
          newRow.appendChild(itemName);
          newRow.appendChild(itemPrice);
          newRow.appendChild(itemFactor);
          newRow.appendChild(checkBoxTd);
          tableBody.appendChild(newRow);
        }
      }
    } catch (error) { itemData.value = ''; }
  });
  buyBtnEl.addEventListener('click', () => {
    let boughtFurnitureNames = [];
    let furnitureTotalPrice = 0;
    let decorationFactors = [];

    for (let i = 0; i < tableBody.children.length; i++) {
      let currentItemDataEls = tableBody.children[i].querySelectorAll('td');
      let currentItemCheckbox = currentItemDataEls[4].querySelector('input');
      if (currentItemCheckbox.checked) {
        boughtFurnitureNames.push(currentItemDataEls[1].firstChild.textContent);
        furnitureTotalPrice += Number(currentItemDataEls[2].firstChild.textContent);
        decorationFactors.push(Number(currentItemDataEls[3].firstChild.textContent));
      }
    }

    if (
      boughtFurnitureNames.length > 0 &&
      decorationFactors.length > 0 &&
      furnitureTotalPrice > 0
    ) {
      resultArea.textContent = '';
      resultArea.textContent += `Bought furniture: ${boughtFurnitureNames.join(', ')}\n`;
      resultArea.textContent += `Total price: ${furnitureTotalPrice.toFixed(2)}\n`;
      resultArea.textContent += `Average decoration factor: ${decorationFactors.reduce((a, b) => a + b) / decorationFactors.length}`;
    }
  });
}