import json
import random

titles_file = 'titles_and_authors.json'
with open(titles_file, 'r', encoding='utf-8') as file:
    titles_data = json.load(file)

quiz_data = []
for item in titles_data:
    title = item['Author']
    author = item['title'] if 'title' in item else "Unknown"
    question = f"{title} Adlı kitabın yazarı kimdir?"
    authors_list = [data['title'] for data in titles_data if 'title' in data]
    options = []
    while len(options) < 3:
        random_author = random.choice(authors_list)
        if random_author != author and random_author not in options:
            options.append(random_author)

    options.append(author)
    random.shuffle(options)
    quiz_data.append({
        'id': str(len(quiz_data)),
        'question': question,
        'options': options,
        'correct': author
    })

# JSON dosyasına yazma
with open('quiz_data.json', 'w', encoding='utf-8') as json_file:
    json.dump(quiz_data, json_file, ensure_ascii=False, indent=4)
