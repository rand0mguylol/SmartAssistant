import feedparser


# d = feedparser.parse("https://news.google.com/news/rss/?hl=en&amp;ned=us&amp;gl=US")
d = feedparser.parse("http://news.google.com/?output=rss")
print(d.keys())

# for _k in list(d.keys()):
#   print(f"\n{_k}: {d[_k]}")

print(d["entries"][0].keys())
print(d["entries"][0]["title"])
print(d["entries"][0]["link"])
print(d["entries"][0]["published"])
print(feedparser.parse(d["entries"][0]["summary"]).keys())
print(d["feed"]["title"])


count = 0
articles = []
print()
for item in d['items']:
  count += 1
  # print(item.keys())
  # print(item["title"])
  # print(item["link"])
  # print(item["summary"])
  # print(item["summary_detail"])
  # print(item["published"])
  break

print(count)

# import fbchat
# from fbchat import Client

# username = input("Email: ")
# password = input("Password: ")

# client = Client(username, password)
# friend_name = input("Friend Name: ")
# friends = client.searchForUsers(friend_name)

# for i, f in enumerate(friends):
#   print(i, f)
# index = int(input("Index Number: "))
# msg = str(input("Message: "))
# sent = client.send(fbchat.models.Message(msg), friends[index].uid)
# if sent:
#   print("Message sent successfully!")