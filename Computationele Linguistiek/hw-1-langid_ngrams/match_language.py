import os
import sys
from typing import List
from langdetect import read_ngrams, ngram_table, cosine_similarity


class LangMatcher:
    """
    Match the language of a random text through ngrams

    """
    def __init__(self, path: str):
        """
        Create the LangMatcher object

        :param str path: path to the texts to match against
        """
        self.path = path

        if not os.path.isdir(path):
            raise IOError("{} is not a directory!".format(path))

        # Get the type of ngram table
        n_limit = path.split("/")[1].split("-")
        self.n = int(n_limit[0])
        self.limit = int(n_limit[1])

        ngrams = {}
        # convert file to ngram table
        for fileName in os.listdir(path):
            ngrams[fileName] = read_ngrams(path + "/" + fileName)

        self.languages = ngrams

    def score(self, text: str, k_best=1) -> List:
        """
        Calculates the score of which language is the most similar

        :param str text: the text to compare against
        :param int k_best: how many scores you want to return

        :return list: returns a list of tuples from high to low score in the format (language, score)
        """
        # Get the table for the given text
        table = ngram_table(text, self.n, self.limit)

        similarity = []

        for language in self.languages.keys():
            similarity.append((language, cosine_similarity(table, self.languages[language])))

        similarity.sort(key=lambda x: x[1], reverse=True)

        return similarity[0:k_best]

    def recognize(self, filename: str, encoding="utf-8") -> List:
        """
        Helper function to quickly calculate the most matching language for one file

        :param str filename: the name of the file
        :param str encoding: type of encoding the given file uses (default: utf-8)

        :return list: returns a list of tuples one tuple in the format (language, score)
        """
        with open(filename, encoding=encoding) as file:
            lines = file.read().replace("\n", '')

        return self.score(lines)


if __name__ == "__main__":
    args = sys.argv
    del args[0]

    if len(args) < 2:
        raise TypeError("Not enough arguments!")

    matcher = LangMatcher(args[0])

    for i in range(1, len(args)):
        print(matcher.recognize(args[i]))

