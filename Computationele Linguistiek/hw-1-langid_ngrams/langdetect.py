import os
import re
import math

from typing import List


def prepare(text: str) -> List:
    """
    Takes a string and replaces !?",.()<> and then splits the text on whitespaces

    :param str text: the string to prepare

    :return: list of strings
    """
    no_punctuation_marks = re.sub(r'[!?,.<>"()]', " ", text)
    return no_punctuation_marks.split()


def ngrams(seq: str, num=3) -> List[str]:
    """"
    Deze functie maakt (en returnt) ngrams van de sequence(string) die wordt ingevoerd.
    De standaard ngrams is een trigram, maar een tweede variabele
    kan daar unigrams, bigrams, quadgrams enz. van maken
    """
    n = 0
    grams = []
    while n < len(seq) - (num - 1):
        token = seq[n:(n + num)]
        grams.append(token)
        n += 1
    return grams


def ngram_table(text: str, n=3, limit=0) -> dict:
    """
    Makes an ngram table from a given text

    :param str text: the text to convert
    :param int n: type of n-gram, unigram, bigram etc.
    :param int limit: how many ngrams to return

    :return: the ngram table
    """
    # Get the text in words and put them in < >
    word_list = prepare(text)
    word_list_plus = []
    for i in range(len(word_list)):
        word_list_plus.append("<" + word_list[i] + ">")

    # Extract the ngrams from the words
    result = {}
    for i in range(len(word_list_plus)):
        ngrams_list = ngrams(word_list_plus[i], n)
        for ngram in ngrams_list:
            if ngram in result:
                result[ngram] += 1
            else:
                result[ngram] = 1

    # Rank the keys of the index by value (frequency)
    sorted_values = sorted(result.values(), reverse=True)
    sorted_dict = {}
    for i in sorted_values:
        for k in result.keys():
            if result[k] == i:
                sorted_dict[k] = result[k]

    # Print the sorted dictionary with a limit
    if limit != 0:
        limit_dict = {}
        for i in range(limit):
            max_val = list(sorted_dict.values())
            max_ke = list(sorted_dict.keys())
            if i < len(max_val):
                limit_dict[max_ke[i]] = max_val[i]
            else:
                break

        return limit_dict
    else:
        return sorted_dict


def read_ngrams(filename: str) -> dict:
    """
    Reads the ngram-table from a file.

    :param str filename: the name of the file
    :return dict

    :raises FileNotFoundError: if the file is not in the ngrams directory
    """
    if os.path.exists("ngrams" + filename):
        raise FileNotFoundError("File does not exist in ngrams directory")

    with open(filename, "r") as file:
        data = file.read()

    lines = data.splitlines()

    result = {}

    for line in lines:
        items = line.split(" ")
        result[items[1]] = int(items[0])

    return result


def write_ngrams(table: dict, filename: str) -> None:
    """
    Write the ngram table to a file

    :param table dict: the ngram table
    :param filename str: the file name

    """
    # Open file and set the correct encoding
    with open(filename, "w", encoding="utf-8") as file:
        for key in table.keys():
            # Write to the file
            file.write("{} {} \n".format(table[key], key))

    return


def magnitude(dictionary: dict) -> float:
    """
    De functie magnitude neemt een dictionary als input en
    bepaalt de lengte van de vector van alle values.
    """
    mag = 0
    for value in dictionary.values():
        mag += value * value
    return math.sqrt(mag)


def cosine_similarity(dic1: dict, dic2: dict) -> float:
    """
    This function has two dictionaries as input and returns the
    similarity between the two. The output is a number between -1.0 and 1.0
    """
    dotproduct = 0
    for key in dic1.keys():
        if key in dic2:
            dotproduct += dic1[key] * dic2[key]
    cossim = dotproduct / (magnitude(dic1) * magnitude(dic2))
    return cossim
