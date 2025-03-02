from contextlib import nullcontext

from selenium import webdriver
from time import sleep
from selenium.webdriver.common.by import By
import os
from selenium.webdriver.chrome.options import Options
from selenium.webdriver import ActionChains
from selenium.webdriver.remote.webelement import WebElement
from tokenize import String
from asyncio import wait_for

option = Options()

option.add_argument("user-data-dir=C:/User/trant/PycharmProject/PythonProject/Profile"+"TCT")
option.add_argument("--disable-infobars")
option.add_argument("start-maximized")
option.add_argument("--disable-extensions")
# Pass the argument 1 to allow and 2 to block
option.add_experimental_option(
    "prefs", {"profile.default_content_setting_values.notifications": 1}
)


driver = webdriver.Chrome(options=option)

def convertToCookie(cookie):
    try:
        new_cookie = ["c_user=", "xs="]
        cookie_arr = cookie.split(";")
        for i in cookie_arr:
            if i.__contains__('c_user='):
                new_cookie[0] = new_cookie[0] + (i.strip() + ";").split("c_user=")[1]
            if i.__contains__('xs='):
                new_cookie[1] = new_cookie[1] + (i.strip() + ";").split("xs=")[1]
                if (len(new_cookie[1].split("|"))):
                    new_cookie[1] = new_cookie[1].split("|")[0]
                if (";" not in new_cookie[1]):
                    new_cookie[1] = new_cookie[1] + ";"

        conv = new_cookie[0] + " " + new_cookie[1]
        if (conv.split(" ")[0] == "c_user="):
            return
        else:
            return conv
    except:
        print("Error Convert Cookie")

def loginFacebookByCookie(driver, cookie):
    try:
        cookie = convertToCookie(cookie)
        print(cookie)
        if (cookie != None):
            script = 'javascript:void(function(){ function setCookie(t) { var list = t.split("; "); console.log(list); for (var i = list.length - 1; i >= 0; i--) { var cname = list[i].split("=")[0]; var cvalue = list[i].split("=")[1]; var d = new Date(); d.setTime(d.getTime() + (7*24*60*60*1000)); var expires = ";domain=.facebook.com;expires="+ d.toUTCString(); document.cookie = cname + "=" + cvalue + "; " + expires; } } function hex2a(hex) { var str = ""; for (var i = 0; i < hex.length; i += 2) { var v = parseInt(hex.substr(i, 2), 16); if (v) str += String.fromCharCode(v); } return str; } setCookie("' + cookie + '"); location.href = "https://mbasic.facebook.com"; })();'
            driver.execute_script(script)
            sleep(5)
    except:
        print("Error login")

def checkLiveClone(driver):
    driver.get("https://mbasic.facebook.com/")
    sleep(10)
    elementLive = driver.find_elements(By.ID, ':Rbadakl6illkqismipapd5aq:')
    if (elementLive):
        print("Live")
        return True
    else:
        print("chua dang nhap")
        return False

def readData(fileName):
    f = open(fileName, 'r', encoding='utf-8')
    data = []
    for i, line in enumerate(f):
        try:
            line = repr(line)
            line = line[1:len(line) - 3]
            data.append(line)
        except:
            print("err")
    return data

def writeFileTxt(fileName, content):
    with open(fileName, 'a') as f1:
        f1.write(content + os.linesep)
fileIds = './post.csv'
def GetPostFanpage(driver, links, numberId):
    driver.get(links)
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight)")
    sleep(20)
    file_exists = os.path.exists(fileIds)
    if (not file_exists):
        writeFileTxt(fileIds, '')
    sumLinks = readData(fileIds)
    while (len(sumLinks) < numberId):
        driver.execute_script("window.scrollTo(0, document.body.scrollHeight)")
        sleep(10)
        likeBtn = driver.find_elements(By.XPATH, '//a[contains(@href, "/posts/")]')
        for id in likeBtn:
            idPost = id.get_attribute('href')
            #vitri = idPost.find("?")
            #link=idPost[:vitri]
            print(idPost)
            #if (link not in sumLinks):
               # sumLinks.append(link)
                #writeFileTxt(fileIds, link)

cookies ="datr=NxeRZyg9Vwr6ttydkrn0Adee;sb=NxeRZ39NYm_K3ycN4lp8T7D5;dpr=1.25;c_user=100010184822153;ps_l=1;ps_n=1;wd=1492x704;xs=41%3AJEp_24imeQjh1w%3A2%3A1737561954%3A-1%3A6351%3A%3AAcXzFSBsT2-qar8_rewOdLBIyrVgCw6tcFunozZIlBvk;ar_debug=1;fr=1WIVRljZg3A6awHbM.AWXPV-Lig-nPUvCRK27wggK45otTWEbtLNhgfw.BnxHv0..AAA.0.0.BnxH1U.AWWsjjssF98;presence=C%7B%22t3%22%3A%5B%5D%2C%22utc3%22%3A1740930399881%2C%22v%22%3A1%7D;";
cookie =convertToCookie(cookies)
islogin = checkLiveClone(driver)
if(islogin == False):
    loginFacebookByCookie(driver,cookie)
else:
    linkfanpage = "https://www.facebook.com/TrenDuongPitch"
    driver.get(linkfanpage)
    driver.execute_script("window.scrollTo(0, document.body.scrollHeight)")
    sleep(20)
    likeBtn = driver.find_elements(By.XPATH, '//a[contains(@href, "/posts/")]')
    for id in likeBtn:
        idPost = id.get_attribute('href')
        vitri1 = idPost.find("comment_id")
        if(vitri1 < 1):
            vitri = idPost.find("?")
            link=idPost[:vitri]
            #print(idPost)
    post = driver.find_elements(By.CSS_SELECTOR, 'div[class="xdj266r x11i5rnm xat24cr x1mh8g0r x1vvkbs x126k92a"]')
    for inforpost in post:
        xemthem = inforpost.find_elements(By.CSS_SELECTOR, 'div[class = "x1i10hfl xjbqb8w x1ejq31n xd10rxx x1sy0etr x17r0tee x972fbf xcfux6l x1qhh985 xm0m39n x9f619 x1ypdohk xt0psk2 xe8uvvx xdj266r x11i5rnm xat24cr x1mh8g0r xexx8yu x4uap5 x18d9i69 xkhd6sd x16tdsg8 x1hl2dhg xggy1nq x1a2a7pz x1sur9pj xkrqix3 xzsf02u x1s688f"]')
        if(xemthem != nullcontext):
            for anxemthem in xemthem:
                anxemthem.click()
        content = inforpost.find_elements(By.CSS_SELECTOR, 'div[dir = "auto"][style = "text-align: start;"]')
        for temp in content:
            print(temp.text)