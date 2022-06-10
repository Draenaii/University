import os
from langdetect import ngram_table, write_ngrams


def make_profiles(datafolder: str, n: int, limit: int) -> None:
    """
    Generates models based on a given corpus

    :param str datafolder: folder where the corpus is located
    :param int n: n for n-gram value
    :param int limit: amount of ngrams in a table
    """
    files = os.listdir(datafolder)  # All the files in 'datafolder'
    path = "./models/" + str(n) + "-" + str(limit) + "/"  # ./models/<n>-<limit>/ path

    for filename in files:
        langenc = filename.split("-")  # [language, encoding]
        with open(datafolder + '/' + filename, "r", encoding=langenc[1]) as file:
            data = file.read()
        table = ngram_table(data, n, limit)
        pathExist = os.path.exists(path)  # Does the path exist?
        if not pathExist:
            # Create a new directory because it does not exist
            os.makedirs(path)
            write_ngrams(table, path + langenc[0])
        else:
            # Write the Ngram table as name of the language
            write_ngrams(table, path + langenc[0])


if __name__ == "__main__":
    make_profiles("./datafiles/training", 3, 200)
    make_profiles("./datafiles/training", 2, 200)
