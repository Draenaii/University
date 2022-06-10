#!/usr/bin/env python
# coding: utf-8

# In[1]:


def nth_char(n, string):
    if len(string) > n:     
        return string[n]
    else:
        return None


# In[2]:


def nth_word(n, string):
    stringlist = string.split()
    if len(stringlist) > n:     
        return stringlist[n]
    else:
        return None


# In[3]:


def nth_of_mth(n, m, string):
    word = nth_word(m, string)
    if word is not None:
        x = nth_char(n, word)
        if x is not None:
            print(x)
        else:
            print("Oops!")
    else:
        print("Oops!")


# In[4]:


nth_char(24, "the quick brown fox jumps over the lazy dog")


# In[5]:


nth_word(3, "the quick brown fox jumps over the lazy dog")


# In[6]:


nth_of_mth(400, 200,"The quick brown fox jumps over the lazy dog")


# In[ ]:




