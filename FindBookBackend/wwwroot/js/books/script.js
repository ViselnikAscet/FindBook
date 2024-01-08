function searchBook() {
    var bookTitle = document.getElementById('username').value;
    var url = 'https://www.googleapis.com/books/v1/volumes?q=' + encodeURIComponent(bookTitle);

    fetch(url)
      .then(response => response.json())
      .then(data => {
        displayBookInfo(data);
      })
      .catch(error => {
        console.log('Hata:', error);
      });
  }

  function displayBookInfo(data) {
    var bookInfoDiv = document.getElementById('bookInfo');
    bookInfoDiv.innerHTML = '';

    if (data.totalItems === 0) {
      bookInfoDiv.innerHTML = 'Kitap bulunamadı.';
      return;
    }

    var book = data.items[0].volumeInfo;
    var title = book.title;
    var authors = book.authors ? book.authors.join(', ') : 'Bilinmiyor';
    var description = book.description || 'Açıklama bulunamadı.';
    var thumbnail = book.imageLinks ? book.imageLinks.thumbnail : '';

    var bookHTML = `
    <a href="https://www.google.com/search?q=${title}+${authors}" target="_blank"> <h2>${title}</h2></a>
      <p><strong>Yazar:</strong> ${authors}</p>
      <img src="${thumbnail}" alt="${title}">
      <p><strong>Açıklama:</strong> ${description}</p>
    `;

    bookInfoDiv.innerHTML = bookHTML;
  }
