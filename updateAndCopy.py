from createPawnKindDefs import createPKD
from factionPatchCreate import createFactionPatch
import sys
sys.path.append('..')

pawnKindDefNamesArray = {}
possibleParents = {}

modPrefix = 'BetaHumanoids'
destinationPathVersion = '1.5'
otherModsPath = 'othermods'

folderName = 'BetaHumanoids'
destinationPathVersion = '1.5'
species = [
    {
        "race": ["BetaBear"],
        "label": "beta bear",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaCamel"],
        "label": "beta camel",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaCroc"],
        "label": "beta crocodile",
        "modifier": 0.7,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaElephant"],
        "label": "beta elephant",
        "modifier": 0.25,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaElk_Female", "BetaElk_Male"],
        "label": "beta elk",
        "modifier": 0.1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaFox"],
        "label": "beta fox",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaGazelle"],
        "label": "beta gazelle",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaHog"],
        "label": "beta hog",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaLynx"],
        "label": "beta lynx",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaRaccoon"],
        "label": "beta raccoon",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
    {
        "race": ["BetaWolf"],
        "label": "beta wolf",
        "modifier": 1,
        "apparelTags": [],
        "apparelRequired": [],
        "xenoType": [{"label": "BetaHumanoids_Baseliner", "modifier": "1"}],
    },
]

# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================
# ================================PAWNKIND========================================


# ================================Core========================================
# ================================Core========================================
# ================================Core========================================
coreModID = 'Core'
pawnKindDefsFiles = [
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Mercenary',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Outlander',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Pirate',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Player',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Spacer',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Special',
    '\\Defs\\PawnKindDefs_Humanlikes\\PawnKinds_Tribal',
    '\\Defs\\PawnKinds\\PawnKinds_Breach',
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    coreModID,
    pawnKindDefNamesArray,
    possibleParents
)


# ================================Ideology========================================
# ================================Ideology========================================
# ================================Ideology========================================


ideologyModID = 'Ideology'
pawnKindDefsFiles = [
    '\\Defs\\PawnKinds\\PawnKinds_NeutralCamps',
    '\\Defs\\PawnKinds\\PawnKinds_Special',
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\'+ideologyModID+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    ideologyModID,
    pawnKindDefNamesArray,
    possibleParents
)
# ================================Royalty========================================
# ================================Royalty========================================
# ================================Royalty========================================


royaltyModId = 'Royalty'
pawnKindDefsFiles = [
    '\\Defs\\PawnKinds\\PawnKinds_Empire',
    '\\Defs\\PawnKinds\\PawnKinds_Refugee',
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\'+royaltyModId+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    royaltyModId,
    pawnKindDefNamesArray,
    possibleParents
)

# # ================================WH40K========================================
# # ================================WH40K========================================
# # ================================WH40K========================================

# modIDFaction_40kAstraMilitarum = '1541499916'
# destinationFolderNameFaction_40kAstraMilitarum = 'Faction_40kAstraMilitarum'
# pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
# pawnKindDefsFiles = [
#     pawnKindFolder+'OG_AMAXB_PawnKinds_ImperialGuard_Abstract',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_ImperialGuard_Cadian',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_ImperialGuard_Player',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_ImperialGuard_Special',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_ImperialGuard',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_Mechanicus_Abstract',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_Mechanicus_Player',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_Mechanicus_Special',
#     pawnKindFolder+'OG_AMAXB_PawnKinds_Mechanicus'
# ]

# pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
#     modPrefix,
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_40kAstraMilitarum+'\\'+destinationPathVersion,
#     pawnKindDefsFiles,
#     species,
#     modIDFaction_40kAstraMilitarum,
#     pawnKindDefNamesArray,
#     possibleParents,
#     False
# )

# # ================================Ancients========================================
# # ================================Ancients========================================
# # ================================Ancients========================================
modIDFaction_Ancients = '2654846754'
destinationFolderNameFaction_Ancients = 'Faction_Ancients'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs_Humanlikes\\'
pawnKindDefsFiles = [
    pawnKindFolder+'PawnKinds_Player',
    pawnKindFolder+'PawnKinds_Spacer'
]

pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_Ancients+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_Ancients,
    pawnKindDefNamesArray,
    possibleParents,
)

# # ================================BlueMoon========================================
# # ================================BlueMoon========================================
# # ================================BlueMoon========================================

modIDFaction_BlueMoon = '1123043922'
destinationFolderNameFaction_BlueMoon = 'Faction_BlueMoon'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs_Humanlikes\\'
pawnKindDefsFiles = [
    pawnKindFolder+'PawnKinds_BlueSunSoldiers_SparklingWorlds'
]

pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_BlueMoon+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_BlueMoon,
    pawnKindDefNamesArray,
    possibleParents
)


# # ================================PolarisBloc========================================
# # ================================PolarisBloc========================================
# # ================================PolarisBloc========================================

# modIDFaction_PolarisBloc = '1500248421'
# destinationFolderNameFaction_PolarisBloc = 'Faction_PolarisBloc'
# pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
# pawnKindDefsFiles = [
#     pawnKindFolder+'PawnKinds_SecuirityForce'
# ]

# pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
#     modPrefix,
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_PolarisBloc+'\\'+destinationPathVersion,
#     pawnKindDefsFiles,
#     species,
#     modIDFaction_PolarisBloc,
#     pawnKindDefNamesArray,
#     possibleParents,
# )

# # ================================PsiTech========================================
# # ================================PsiTech========================================
# # ================================PsiTech========================================

# modIDFaction_PsiTech = '2078892294'
# destinationFolderNameFaction_PsiTech = 'Faction_PsiTech'
# pawnKindFolder = '\\v1.5\\Defs\\PawnKindDefs\\'
# pawnKindDefsFiles = [
#     pawnKindFolder + 'PawnKinds_PsiTech'
# ]
# pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
#     modPrefix,
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_PsiTech+'\\'+destinationPathVersion,
#     pawnKindDefsFiles,
#     species,
#     modIDFaction_PsiTech,
#     pawnKindDefNamesArray,
#     possibleParents,
# )

# # ================================RimsenalFed========================================
# # ================================RimsenalFed========================================
# # ================================RimsenalFed========================================

modIDFaction_RimsenalFederation = '736172213'
destinationFolderNameFaction_RimsenalFederation = 'Faction_RimsenalFederation'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
pawnKindDefsFiles = [
    pawnKindFolder + 'PawnKinds_Aux'
]

pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RimsenalFederation+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_RimsenalFederation,
    pawnKindDefNamesArray,
    possibleParents,
)

# # ================================RimsenalFeral========================================
# # ================================RimsenalFeral========================================
# # ================================RimsenalFeral========================================

modIDFaction_RimsenalFeral = '736207111'
destinationFolderNameFaction_RimsenalFeral = 'Faction_RimsenalFeral'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
pawnKindDefsFiles = [
    pawnKindFolder + 'PawnKinds_Feral'
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RimsenalFeral+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_RimsenalFeral,
    pawnKindDefNamesArray,
    possibleParents,
)

# # ================================RimworldOfMagic========================================
# # ================================RimworldOfMagic========================================
# # ================================RimworldOfMagic========================================

# modIDFaction_RimworldOfMagic = '1201382956'
# destinationFolderNameFaction_RimworldOfMagic = 'Faction_RimworldOfMagic'
# pawnKindFolder = '\\v1.5\\Defs\\PawnDefs\\'
# pawnKindDefsFiles = [
#     pawnKindFolder + 'PawnKind_Mage_Defs'
# ]
# pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
#     modPrefix,
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_RimworldOfMagic+'\\'+destinationPathVersion,
#     pawnKindDefsFiles,
#     species,
#     modIDFaction_RimworldOfMagic,
#     pawnKindDefNamesArray,
#     possibleParents,
# )

# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================

modIDFaction_RWP = '2237100861'
destinationFolderNameFaction_RWP = 'Faction_RWP'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs_Humanlikes\\'
pawnKindDefsFiles = [
    pawnKindFolder + 'RWP_Pawnkinds_Bandit',
    pawnKindFolder + 'RWP_Pawnkinds_Marshal',
    pawnKindFolder + 'RWP_Pawnkinds_Town'
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RWP+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_RWP,
    pawnKindDefNamesArray,
    possibleParents,
)

# # ================================StarWarsFactions========================================
# # ================================StarWarsFactions========================================
# # ================================StarWarsFactions========================================

modIDFaction_SWFactions = '918227266'
destinationFolderNameFaction_SWFactions = 'Faction_SWFactions'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
pawnKindDefsFiles = [
    pawnKindFolder + 'PawnKinds_Imp',
    pawnKindFolder + 'PawnKinds_Rebel',
    pawnKindFolder + 'PawnKinds_Scum'
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_SWFactions+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_SWFactions,
    pawnKindDefNamesArray,
    possibleParents,
)

# # ================================StarWarsFirstOrder========================================
# # ================================StarWarsFirstOrder========================================
# # ================================StarWarsFirstOrder========================================

# modIDFaction_SWFirstOrder = '2395173388'
# destinationFolderNameFaction_SWFirstOrder = 'Faction_SWFirstOrder'
# pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
# pawnKindDefsFiles = [
#     pawnKindFolder + 'PawnKinds_FROR',
#     pawnKindFolder + 'PawnKinds_Player_FROR',
# ]
# pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
#     modPrefix,
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_SWFirstOrder+'\\'+destinationPathVersion,
#     pawnKindDefsFiles,
#     species,
#     modIDFaction_SWFirstOrder,
#     pawnKindDefNamesArray,
#     possibleParents,
# )

# # ================================VEF Settlers========================================
# # ================================VEF Settlers========================================
# # ================================VEF Settlers========================================

modIDFaction_VESettlers = '2052918119'
destinationFolderNameFaction_VESettlers = 'Faction_VESettlers'
pawnKindFolder = '\\1.5\\Defs\\PawnKindDefs\\'
pawnKindDefsFiles = [
    pawnKindFolder + 'PawnKinds_Bandits',
    pawnKindFolder + 'PawnKinds_Settlers',
    pawnKindFolder + 'PawnKinds_Player',
]
pawnKindDefNamesArray, pawnKindDefsArray = createPKD(
    modPrefix,
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_VESettlers+'\\'+destinationPathVersion,
    pawnKindDefsFiles,
    species,
    modIDFaction_VESettlers,
    pawnKindDefNamesArray,
    possibleParents,
)

# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================
# ================================FACTIONS========================================



# ================================CORE========================================
# ================================CORE========================================
# ================================CORE========================================

factionFileNames = [
    '\\Defs\\FactionDefs\\Factions_Misc'
]
createFactionPatch(
    folderName+'\\'+destinationPathVersion,
    factionFileNames,
    coreModID,
    species,
    pawnKindDefNamesArray
)

# ================================Ideology========================================
# ================================Ideology========================================
# ================================Ideology========================================
factionFileNames = [
    '\\Defs\\FactionDefs\\Factions_Misc'
]
createFactionPatch(
    folderName + '\\'+otherModsPath+'\\'+ideologyModID+'\\'+destinationPathVersion,
    factionFileNames,
    ideologyModID,
    species,
    pawnKindDefNamesArray
)

# ================================Royalty========================================
# ================================Royalty========================================
# ================================Royalty========================================
factionFileNames = [
    '\\Defs\\FactionDefs\\Faction_Empire',
    '\\Defs\\FactionDefs\\Factions_Misc',
]
createFactionPatch(
    folderName + '\\'+otherModsPath+'\\'+royaltyModId+'\\'+destinationPathVersion,
    factionFileNames,
    royaltyModId,
    species,
    pawnKindDefNamesArray
)

# # ================================WH40K========================================
# # ================================WH40K========================================
# # ================================WH40K========================================
# factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
# factionFileNames = [
#     factionDefFolder+'OG_AMAXB_Factions_ImperialGuard_Abstract',
#     factionDefFolder+'OG_AMAXB_Factions_ImperialGuard_Cadian',
#     factionDefFolder+'OG_AMAXB_Factions_Mechanicus',
# ]

# createFactionPatch(
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_40kAstraMilitarum+'\\'+destinationPathVersion,
#     factionFileNames,
#     modIDFaction_40kAstraMilitarum,
#     species,
#     pawnKindDefNamesArray
# )
# ================================Ancients========================================
# ================================Ancients========================================
# ================================Ancients========================================

factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'Factions_Hidden',
    factionDefFolder+'Factions_Player'
]
createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_Ancients+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_Ancients,
    species,
    pawnKindDefNamesArray
)

# # ================================BlueMoon========================================
# # ================================BlueMoon========================================
# # ================================BlueMoon========================================

factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'Factions_BlueMoonCorp_SparklingWorlds'
]

createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_BlueMoon+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_BlueMoon,
    species,
    pawnKindDefNamesArray
)

# # ================================PolarisBloc========================================
# # ================================PolarisBloc========================================
# # ================================PolarisBloc========================================
# factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
# factionFileNames = [
#     factionDefFolder+'Factions_SecuirityForce'
# ]


# createFactionPatch(
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_PolarisBloc+'\\'+destinationPathVersion,
#     factionFileNames,
#     modIDFaction_PolarisBloc,
#     species,
#     pawnKindDefNamesArray
# )

# # ================================PsiTech========================================
# # ================================PsiTech========================================
# # ================================PsiTech========================================
# factionDefFolder = '\\v1.5\\Defs\\FactionDefs\\'
# factionFileNames = [
#     factionDefFolder+'Factions_PsiTech'
# ]


# createFactionPatch(
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_PsiTech+'\\'+destinationPathVersion,
#     factionFileNames,
#     modIDFaction_PsiTech,
#     species,
#     pawnKindDefNamesArray
# )

# # ================================RimsenalFed========================================
# # ================================RimsenalFed========================================
# # ================================RimsenalFed========================================
factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'FedFaction'
]


createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RimsenalFederation+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_RimsenalFederation,
    species,
    pawnKindDefNamesArray
)
# # ================================RimsenalFeral========================================
# # ================================RimsenalFeral========================================
# # ================================RimsenalFeral========================================
factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'Factions_Feral'
]


createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RimsenalFeral+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_RimsenalFeral,
    species,
    pawnKindDefNamesArray
)
# # ================================RimworldOfMagic========================================
# # ================================RimworldOfMagic========================================
# # ================================RimworldOfMagic========================================

# factionDefFolder = '\\v1.5\\Defs\\FactionDefs\\'
# factionFileNames = [
#     factionDefFolder+'Factions_Arcane'
# ]

# createFactionPatch(
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_RimworldOfMagic+'\\'+destinationPathVersion,
#     factionFileNames,
#     modIDFaction_RimworldOfMagic,
#     species,
#     pawnKindDefNamesArray
# )


# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================
# # ================================RimworldWesternProject========================================

factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'RWP_Factions_Bandit',
    factionDefFolder + 'RWP_Factions_Marshal',
    factionDefFolder+'RWP_Factions_Town'
]


createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_RWP+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_RWP,
    species,
    pawnKindDefNamesArray
)

# # ================================StarWarsFactions========================================
# # ================================StarWarsFactions========================================
# # ================================StarWarsFactions========================================

factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'Faction_Imperial',
    factionDefFolder+'Faction_Rebel',
    factionDefFolder+'Faction_Scum'
]

createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_SWFactions+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_SWFactions,
    species,
    pawnKindDefNamesArray
)


# # ================================StarWarsFirstOrder========================================
# # ================================StarWarsFirstOrder========================================
# # ================================StarWarsFirstOrder========================================

# factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
# factionFileNames = [
#     factionDefFolder + 'Faction_FirstOrder'
# ]

# createFactionPatch(
#     folderName + '\\'+otherModsPath+'\\' +
#     destinationFolderNameFaction_SWFirstOrder+'\\'+destinationPathVersion,
#     factionFileNames,
#     modIDFaction_SWFirstOrder,
#     species,
#     pawnKindDefNamesArray
# )

# # ================================VEF Settlers========================================
# # ================================VEF Settlers========================================
# # ================================VEF Settlers========================================

factionDefFolder = '\\1.5\\Defs\\FactionDefs\\'
factionFileNames = [
    factionDefFolder+'Factions_Settlers'
]


createFactionPatch(
    folderName + '\\'+otherModsPath+'\\' +
    destinationFolderNameFaction_VESettlers+'\\'+destinationPathVersion,
    factionFileNames,
    modIDFaction_VESettlers,
    species,
    pawnKindDefNamesArray
)
