# MSL-Dataset-Labeling
![RCT Logo](https://rct.univ-tln.fr/wp-content/uploads/IMG_0206-1.jpg)

The dataset of robot's images containt 8 classes of object.
Respect this order when creating a deeplabel project:

* robot
* ballon
* but
* poteau
* joueur_bleu
* joueur_rouge
* robot_rct
* humain


## Warning for exports :
Sometimes for already labelled datasets the class order is robot, ballon, but ...
sometimes robot, human, but ...
You want to modify the classes order if fusing multiple datasets. Double check the batch once they are created to be sure a robot is not labelled as ballon for instance.

## This dataset contains :

* Images set of Robots (Set from [NuBot Dataset](https://github.com/Abbyls/robocup-MSL-dataset) with more images added)
* Images set of Robots and Ball from our robot's omnivision camera
* Images set of Ball (Not MSL)
* Librairies to labelize images and to generate training set using [DeepLabel Tool](https://github.com/jveitchmichaelis/deeplabel)


## Creating a file with all txt labels (for darknet or import)
In powershell admin run : `Set-ExecutionPolicy RemoteSigned`
Then run .\script.ps1
