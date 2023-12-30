import json

titles_file = 'RomanYerli.json'
with open(titles_file, 'r', encoding='utf-8') as file:
    titles_data = json.load(file)

type_name = "Çocuk Kitapları"  # Eklemek istediğiniz type adını belirleyebilirsiniz

# Her bir öğeye id ve type ekleyerek yeni bir liste oluşturuyoruz
new_data = []
for idx, item in enumerate(existing_data, start=1):
    new_item = {
        "id": idx,
        "Author": item["Author"],
        "title": item["title"],
        type_name: "your_type_here"  # Burada istediğiniz type'ı belirleyebilirsiniz
    }
    new_data.append(new_item)

# Oluşturulan verileri mevcut dosyanın üzerine yazma
with open('existing_data.json', 'w', encoding='utf-8') as file:
    json.dump(new_data, file, indent=4, ensure_ascii=False)
