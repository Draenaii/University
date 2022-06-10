import os
from langdetect import ngram_table
from match_language import LangMatcher


def eval(model_path, test_path):
    """"
    returnt name van de testfile, de taal waarvan we denken dat het is, (als het fout is) gevolgd door ERROR, correcte taal.
    en dat voor alle testfiles in de test_path
    """
    taalsuffix = {'da': 'Danish', 'de': 'German', 'el': 'Greek', 'en': 'English', 'es': 'Spanish', 'fi': 'Finnish',
                  'fr': 'French', 'it': 'Italian', 'nl': 'Dutch', 'pt': 'Portuguese', 'sv': 'Swedish'}

    if not os.path.isdir(test_path):
        raise IOError("Test path is not a directory!")

    if not os.path.isdir(model_path):
        raise IOError("Model path is not a directory!")

    matcher = LangMatcher(model_path)

    correct = 0
    incorrect = 0
    for file in os.listdir(test_path):
        language = taalsuffix[file.split(".")[1]]
        result = matcher.recognize(test_path + file)

        if language != result[0][0]:
            print("{} {} ERROR {}".format(file, result[0][0], language))
            incorrect += 1
        else:
            correct += 1

    print("RESULT:")
    print("Model path: {}".format(model_path))
    print("Test path: {}".format(test_path))
    print("Correct: {}".format(correct))
    print("Incorrect: {}".format(incorrect))


if __name__ == "__main__":
    test_sets = ["europarl-90/", "europarl-30/", "europarl-10/"]

    for test in test_sets:
        print("----------------------------------------------------------------")
        print("Trigrams")
        eval("models/3-200", "datafiles/test/" + test)
        print("\n")
        print("Bigrams")
        eval("models/2-200", "datafiles/test/" + test)