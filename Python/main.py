import time
from selenium import webdriver
import json

driver = webdriver.Firefox()
driver.get('https://onedio.com/haber/turk-edebiyati-nin-en-iyi-100-romani-listesi-yenilendi-iste-yeni-liste-774726')
time.sleep(2)

titles = driver.find_elements("xpath",
                              "//html/body/div[1]/div/div/div/div[1]/div[3]/div[2]/div[2]/div[1]/div/article/section/h2")
book_list = []
for title in titles:
    title_text = title.text
    title_parts = title_text.split(' - ')
    if len(title_parts) == 2:
        rank = title_parts[0].split(maxsplit=1)[1]
        book_name = title_parts[1]
        book_list.append({
            'Author': rank,
            'title': book_name
        })
# JSON dosyasına yazma
with open('titles_and_authors.json', 'w', encoding='utf-8') as file:
    json.dump(book_list, file, ensure_ascii=False, indent=4)

driver.quit()