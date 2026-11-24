## Les deux scènes

Le projet contient deux scènes dans `Assets/Scenes/`.

### Scène `Lab` : l'Editor et la physique (Parties 1 et 2)

Une salle de test pour apprendre l'Editor et la physique.

- **Salle** : sol et quatre murs faits de cubes, regroupés sous un objet `Room`
- **Balle** : sphère avec un Rigidbody et le matériau physique `Bouncy` (Bounciness 0.8, Bounce Combine Maximum)
- **Obstacles** : une rampe, deux piliers, une pyramide de six caisses
- **Tour** : cinq instances du prefab `Block`, que la balle renverse
- **Script** : `BounceCounter` affiche chaque collision et sa vitesse dans la Console

### Scène `DemoApp` : l'application de démonstration (Partie 3)

La scène principale du TP : une voiture conduite au clavier dans une arène.

- **Arène** : sol 30 × 30 avec quatre murs, caisses, piliers, rampe de saut et mur de 12 blocs
- **Voiture** : cubes et cylindres sous un objet `Car` (Rigidbody, Box Collider, tag `Player`)
- **Caméra** : `CameraFollow` suit la voiture
- **Pièces** : cinq instances du prefab `Coin`, ramassées via un trigger
- **Score** : `CoinCounter` compte les pièces et annonce la victoire (`Game Manager`)

## Objectif de la démo

Ramasser les **5 pièces** : la Console affiche `Coins: 1 / 5` jusqu'à `All coins collected!`.

## Améliorations

- Score affiché à l'écran avec TextMeshPro
- Valeurs différentes pour les pièces

## Auteur

**Laila MAKHTARI**, Master Technologies Immersives, ENSAM Casablanca, 2026-2027
