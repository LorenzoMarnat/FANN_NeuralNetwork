# FANN_NeuralNetwork

Le but de ce projet est de reconnaitre la langue d'un texte (français, anglais ou polonais). Pour cela, on utilise un réseau de neurones entrainé sur des textes dans ces trois langues.
Le réseau de neurones est implémenté avec la librairie FANN (http://leenissen.dk/fann/wp/).

## Textes

Les textes d'apprentissage (french.txt, english.txt et polish.txt) et les textes de test (testFrench, testEnglish, testPolish) sont disponibles dans le git. Par défaut, le programme va chercher ces fichiers dans "E:/_nomDuFichier_".

Le résultat du réseau de neurones est renvoyé sous la forme des trois entiers compris entre 0 et 1. Chaque entier correspond à un langage, respectivement le français, l'anglais et le polonais. Un entier proche de 1 signifie que le réseau a identifié le texte comme étant du langage correspondant.

Un langage est reconnu grâce à la fréquence d'apparition de chaque lettre.

## Exemples

### Français
Avec le fichier _testFrench_

![testFrench](https://github.com/LorenzoMarnat/FANN_NeuralNetwork/blob/main/Results/testFrench.PNG)

Le premier entier à _1_ montre que le réseau a identifié du français

### Polonais

Avec le fichier _testPolish_

![testFrench](https://github.com/LorenzoMarnat/FANN_NeuralNetwork/blob/main/Results/testPolish.PNG)

Le troisième entier à _1_ montre que le réseau a identifié du polonais

### Anglais

Avec le fichier _testEnglish_

![testFrench](https://github.com/LorenzoMarnat/FANN_NeuralNetwork/blob/main/Results/testEnglish.PNG)

Le deuxième entier proche de _1_ montre que le réseau a identifié du anglais
