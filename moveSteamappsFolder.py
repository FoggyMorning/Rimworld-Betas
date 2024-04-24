import shutil
import os

# the current version's folder
steamModsPath = 'C:\\Program Files (x86)\\Steam\\steamapps\\common\\RimWorld\\Mods\\BetaHumanoids'
personalPath = os.getcwd()


def emptyFolderCreateIfNotExists(folderPath):
    try:
        shutil.rmtree(folderPath)
    except OSError as error:
        print(error)
        os.makedirs(folderPath)
        shutil.rmtree(folderPath)


emptyFolderCreateIfNotExists(steamModsPath + '\\1.5')
emptyFolderCreateIfNotExists(steamModsPath + '\\othermods')

shutil.copytree(personalPath+'\\1.5', steamModsPath+'\\1.5')
shutil.copytree(personalPath+'\\othermods', steamModsPath+'\\othermods')
shutil.copyfile(personalPath+'\\LoadFolders.xml',
                steamModsPath+'\\LoadFolders.xml')
shutil.copyfile(personalPath+'\\About\\About.xml',
                steamModsPath+'\\About\\About.xml')
shutil.copyfile(personalPath+'\\About\\preview.png',
                steamModsPath+'\\About\\preview.png')