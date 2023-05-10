function solve() {
   const tableData = Array.from(document.querySelectorAll('.container tbody td'));
   const tableRows = Array.from(document.querySelectorAll('.container tbody tr'));
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      for (const row of tableRows) {
         row.classList.remove('select');
      }

      let searchTermEl = document.getElementById('searchField');
      for (const data of tableData) {
         if (data.textContent.includes(searchTermEl.value)) {
            data.parentElement.classList.add('select');
         }
      }
      searchTermEl.value = '';
   }
}