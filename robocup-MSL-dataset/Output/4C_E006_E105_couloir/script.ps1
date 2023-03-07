New-Item -Path '.\val.txt' -ItemType File
New-Item -Path '.\train.txt' -ItemType File

$a_val=Get-ChildItem -Recurse -include *.jpg .\val\
$a_train=Get-ChildItem -Recurse -include *.jpg .\train\

#$b_val=$a_val.name| foreach { "val\" + $_ }
#$b_train=$a_train.name| foreach { "train\" + $_ }

Add-content -Path '.\val.txt' -Value $a_val
Add-content -Path '.\train.txt' -Value $a_train


