import re
from nltk.corpus import gutenberg

if __name__ == "__main__":
    def alice() -> list:
        words = gutenberg.words("carroll-alice.txt")
        words = [w.lower() for w in words if re.search(r'\w', w)]
        my_dict = {}
        for i in range(len(words)):
            word = words[i]
            if word == 'alice':
                vw = i + 1
                if words[vw] in my_dict:
                    my_dict[words[vw]] += 1
                else:
                    my_dict[words[vw]] = 1

        return sorted(my_dict.items(), key=lambda x: x[1],reverse=True)

    def breakdown():
        my_list = alice()
        for i in range(5):
            word = my_list[i][0]
            freq = str(my_list[i][1])
            print(word + ' ' + freq)

    breakdown()