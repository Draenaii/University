import sys
from nltk.corpus import brown

def categories(words):
    for arg in words:
        tagcount = {}
        for (word, tag) in brown.tagged_words(tagset="universal"):
            if arg.lower() == word.lower():
                if tag in tagcount:
                    tagcount[tag] += 1
                else:
                    tagcount[tag] = 1
        data = arg + " "
        for i in tagcount:
            data += i + " " + str(tagcount[i]) + " "
        print(data)

if __name__ == '__main__':
    wordslist = sys.argv[1:]
    categories(wordslist)