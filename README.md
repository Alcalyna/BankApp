# Note de livraison - Session 1

### Date de livraison 
- Vendredi 27 mai 2022 à 23h59.

### Lien bitbucket
- [Lien Bitbucket](https://bitbucket.org/blacroix/prbd-2122-g21/src/master/)

### Analyse
- Les diagrammes de classes prévisionnel du modèle se trouvent [ici](Analysis).

### Technique
- Les diagrammes de classes *as-built* du modèle se trouvent [ici](Technique).

### Code source
- Le code source se trouve [ici](MoneyInTheBank\MoneyInTheBank).

### Fonctionnalités non implémentées
- Aucune à ma connaissance.

### Fonctionnalités partiellement implémentées
- Le solde temporaire de chaque transaction (les montants ne correspondent pas avec la vidéo).

### Fonctionnalités supplémentaires
- Suppression des accès d'un client à des comptes en respectant le fait qu'un accès ne peut être supprimé que s'il est de type `PROXY` ou s'il reste au moins un `OWNER` du compte.
- Encodage d'un virement provenant d'un compte externe en tant qu'admin.
- Ajout d'un compte externe en tant qu'admin.
    
### Bugs connus

#### Mise à jour d'une catégorie depuis une transaction
- *Pas de catégorie* vers *quelconque catégorie* : ok
- *Quelconque catégorie* vers *quelconque catégorie* : ok
- *Quelconque catégorie* vers *pas de catégorie* : ok
- *Pas de catégorie* vers *pas de catégorie* : BUG

#### Bouton Cancel lors de la créaction d'une nouvelle transaction (`Client` **et** `Admin`)
- Lors de la première connexion d'un utilisateur, il peut créer une nouvelle transaction et appuyer directement sur le bouton `Cancel`, il n'y a pas de problème.
- Il suffit qu'un utilisateur se déconnecte et se reconnecte, qu'ensuite il crée une nouvelle transaction et l'annule tout de suite pour que le bouton `Cancel` affiche un message d'erreur `You have unsaved changes and/or errors`. En débugguant, dans le `Framework`, j'ai, au second `Cancel`, la variable `vm.HasErrors` qui est à `true` bien que j'aie mis `ClearErrors()` un peu partout (pourquoi cela fonctionnerait la première fois et pas la seconde fois ?).