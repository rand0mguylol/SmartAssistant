import requests
import urllib




class Util(object):

  def __init__(self, verbose):
    self.verbose = verbose
    self.current_log = ""

  @classmethod
  def checkInternet(self):
    url = 'http://www.google.com/'
    timeout = 5
    try:
      _ = requests.get(url, timeout=timeout)
      return True
    except requests.ConnectionError:
      return  False

  def _print(self, content):
    if self.verbose >= 1:
      self.current_log = content
      print(content)

  def _print2(self, content):
    if self.verbose >= 2:
      self.current_log = content
      print(content)

  @classmethod
  def generateTinyUrl(self, url):
    """
    Generates a compressed URL.
    Arguments:
        URL -- the original URL to-be compressed
    """
    target = "http://tinyurl.com/api-create.php?url=" + url
    response = urllib.request.urlopen(target)
    return response.read().decode("utf-8")

if __name__ == "__main__":
  print(Util.generateTinyUrl("google.com"))