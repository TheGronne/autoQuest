   M S B A M L   `   `   `  ����E  AAuto Quest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Auto_Quest
Auto_Quest  5   	       Auto_Quest.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Auto_Quest     5   	     � Title$  
MainWindow��5   	   $	��650��6   $	��800��6)    � 
ResizeMode$ NoResize=�65   .��5
      �� 
���   �$��2q�6!   ._�5   
   �  � RowDefinitions 5      �� 5      $��150px �6    �� 5      $
��75px �6    �� 5      $
��75px �6    �� 5      $��275px �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      $��300px �6#   �� 5      $��300px �6#   �� 5      $��* �6#   .+�5      �� -   5         ��Name$ 
StoryLabel��5      $��	0,0,0,125q�6(   $��Story��6;   $
��Bold"�6K   $
��30px��6]   $��0��6k   $��2��6x   $��1��6�   �� 5      -   5        $ EquipmentLabel��5      $��	0,0,0,125q�6,   $��	Equipment��6?   $
��Bold"�6S   $
��30px��6e   $��0��6s   $��1��6�   $��1��6�   �� 5      -   5        $ CharacterLabel��5      $��	0,0,0,125q�6,   $��Character Panel��6?   $
��Bold"�6Y   $
��30px��6k   $��0��6y   $��0��6�   $��1��6�   �� 5      -   5        $ 
StatsLabel��5      $��0,0,0,50q�6(   $��Stats��6:   $
��Bold"�6J   $
��30px��6\   $��1��6j   $��0��6w   $��1��6�   �� 5      -   5        $ QuestsLabel��5      $��0,0,0,50q�6)   $��Quests��6;   $
��Bold"�6L   $
��30px��6^   $��2��6l   $��2��6y   $��1��6�   �� 5      -   5        $ InventoryLabel��5      $��0,0,0,50q�6,   $��	Inventory��6>   $
��Bold"�6R   $
��30px��6d   $��2��6r   $��1��6   $��1��6�   �� 5      -   5        $ SkillsLabel��5      $��	0,0,0,250q�6)   $��Skills��6<   $
��Bold"�6M   $
��30px��6_   $��3��6m   $��0��6z   $��1��6�   �� 5!      $��1q�6   
�������$
��30px��6<   $��100px��6J   $��3��6X   $��0��6e   $��200,0,0,200q�6u   ._�5"      �� -   5        $ SkillLevelLabel��5"      $��Level��61   $��Italic$�6A   5#      �� 5$      $��1q�6   
�������$
��30px��6<   $��200px��6J   $��3��6X   $��0��6e   $��0,0,100,200q�6u   ._�5%      �� -	   5        $ SkillNameLabel��5%      $��Skill��60   $��Italic$�6@   5&      �� 5(      $��1q�6   
�������$
��30px��6<   $��100px��6J   $��2��6X   $��1��6e   $��	200,0,0,0q�6u   ._�5)      �� -
   5        $ IntventoryQuantityLabel��5)      $��Quantity��69   $��Italic$�6L   5*      �� 5+      $��1q�6   
�������$
��30px��6<   $��2��6J   $��200px��6W   $��1��6e   $��	0,0,100,0q�6u   ._�5,      �� -   5        $ InventoryNameLabel��5,      $
��Name��64   $��Italic$�6C   5-      �� 5/      $��1q�6   
�������$
��30px��6<   $��200px��6J   $��0��6X   $��0��6e   $��
100,0,0,75q�6u   ._�50      �� -   5        $ CharacterValueLabel��50      $��Value��65   $��Italic$�6E   51      �� 52      $��1q�6   
�������$
��30px��6<   $��0��6J   $��100px��6W   $��0��6e   $��
0,0,200,75q�6u   ._�53      �� -   5        $ CharacterNameLabel��53      $
��Name��64   $��Italic$�6C   54      �� 56      $��1q�6   
�������$
��30px��6<   $��100px��6J   $��0��6X   $��1��6e   $��
200,0,0,75q�6u   ._�57      �� -   5        $ EquipmentRarityLabel��57      $��Rarity��66   $��Italic$�6G   58      �� 59      $��1q�6   
�������$
��30px��6<   $��0��6J   $��200px��6W   $��1��6e   $��
0,0,100,75q�6u   ._�5:      �� -   5        $ EquipmentNameLabel��5:      $
��Name��64   $��Italic$�6C   5;      �� 5=      $
��Auto=�6   $��0,25,0,0q�6@   $��0��6R   $��2��6_   $��2��6o   .��5>      �� -   5         ��Name$ 
StoryPanel��5>      .+�5?      �� -   5        $ Type1��5?      $�� ��6+   $
��25px��66   5@      5A      �� 5B      $
��Auto=�6   $��0,25,0,0q�6@   $��2��6R   $��2��6_   $��2��6o   .��5C      �� -   5        $ 
QuestPanel��5C      .+�5D      �� -   5        $ Type2��5D      $�� ��6+   $
��25px��66   5E      5F      �� 5G      $
��Auto=�6   $��0,53,0,0q�6@   $��2��6R   $��1��6_   $��2��6o   .��5H      �  5I      �� 5J      $��* �6(    5L      �� 5M      $��200px �6+   �� 5N      $
��50px �6+   .+�5Q      �� -   5        $ InventoryNamePanel��5Q   >   $��0��6!   $��0��6.   $��0,0,0,0q�6Z   .+�5R      �� -   5        $
 Gold��5R       $��Gold: ��6.   $
��25px��6?   5S      �� 5T      -   5        $ InventoryQuantityPanel��5T   >   $��0��6!   $��1��6.   $��0,0,0,0q�6^   .+�5U      �� -   5        $ GoldQTY��5U       $��0 ��61   $
��25px��6>   5V      5W      5X      �� 5Y      $
��Auto=�6   $��0,53,0,0q�6@   $��3��6R   $��0��6_   $��1��6o   .��5Z      �� -   5        $ SkillsPanel��5Z      .+�5[      �� -   5        $ Type4��5[      $�� ��6+   $
��25px��66   5\      5]      �� 5_      -   5        $ 
StatsPanel��5_      $��
5,25,150,0q�6-   $��1��6A   $��0��6N   $��2��6^   .+�5`      �� -   5        $ ATKLabel��5`      $��2q�6*   $��ATK: ��66   $
��25px��6F   $��12(�6T   �� 5a      -   5        $ INTLabel��5a      $��2q�6*   $��INT: ��66   $
��25px��6F   $��12(�6T   �� 5b      -   5        $ SPDLabel��5b      $��2q�6*   $��SPD: ��66   $
��25px��6F   $��12(�6T   �� 5c      -   5        $ CHALabel��5c      $��2q�6*   $��CHA: ��66   $
��25px��6F   $��12(�6T   5d      �� 5e      -   5        $ StatsPanel2��5e      $��
150,25,0,0q�6.   $��1��6B   $��0��6O   $��2��6_   .+�5f      �� -    5        $ ATKSPDLabel��5f      $��2q�6-   $��ATKSPD: ��69   $
��25px��6L   $��12(�6Z   �� 5g      -!   5        $ 	CRITLabel��5g      $��2q�6+   $��CRIT: ��67   $
��25px��6H   $��12(�6V   �� 5h      -"   5        $ MGCLabel��5h      $��2q�6*   $��MGC: ��66   $
��25px��6F   $��12(�6T   �� 5i      -#   5        $ STRLabel��5i      $��2q�6*   $��STR: ��66   $
��25px��6F   $��12(�6T   5j      �� 5l      -$   5        $ CharacterPanel1��5l      $��
0,50,100,0q�62   $��0��6F   $��0��6S   $��1��6c   .+�5m      �� -%   5        $ 	NameLabel��5m      $��Name: ��6+   $
��35px��6<   $��15(�6J   �� 5n      -&   5        $ 
ClassLabel��5n      $��Class: ��6,   $
��35px��6>   $��15(�6L   �� 5o      -'   5        $ 
LevelLabel��5o      $��Level: ��6,   $
��30px��6>   $��15(�6L   5p      �� 5q      -(   5        $ CharacterPanel2��5q      $��
100,50,0,0q�62   $��0��6F   $��0��6S   $��1��6c   .+�5r      �� -)   5        $ NameValueLabel��5r      $�� ��60   $
��35px��6;   $��15(�6I   �� 5s      -*   5        $ ClassValueLabel��5s      $�� ��61   $
��35px��6<   $��15(�6J   �� 5t      -+   5        $ LevelValueLabel��5t      $�� ��61   $
��30px��6<   $��15(�6J   5u      �� 5v      -,   5        $ EquipmentPanel��5v      $��
0,50,100,0q�61   $��0��6E   $��1��6R   $��2��6b   .+�5w      �� --   5        $ Weapon��5w      $��Weapon: ��6(   $
��25px��6;   $��11(�6I   �� 5x      -.   5        $ Shield��5x      $��Shield: ��6(   $
��25px��6;   $��11(�6I   �� 5y      -/   5        $
 Helm��5y      $��Helm: ��6&   $
��25px��67   $��11(�6E   �� 5z      -0   5        $ Breastplate��5z      $��Breastplate: ��6-   $
��25px��6E   $��11(�6S   �� 5{      -1   5        $ Greaves��5{      $��	Greaves: ��6)   $
��25px��6=   $��11(�6K   �� 5|      -2   5        $ Boots��5|      $��Boots: ��6'   $
��25px��69   $��11(�6G   �� 5}      -3   5        $ Special��5}      $��	Special: ��6)   $
��25px��6=   $��11(�6K   5~      �� 5      -4   5        $ EquipmentPanel2��5      $��
200,50,0,0q�62   $��0��6F   $��1��6S   $��2��6c   .+�5�      �� -5   5        $ WeaponRarityLabel��5�      $�� ��63   $
��25px��6>   $��11(�6L   �� 5�      -6   5        $ ShieldRarityLabel��5�      $�� ��63   $
��25px��6>   $��11(�6L   �� 5�      -7   5        $ HelmRarityLabel��5�      $�� ��61   $
��25px��6<   $��11(�6J   �� 5�      -8   5        $ BreastplateRarityLabel��5�      $�� ��68   $
��25px��6C   $��11(�6Q   �� 5�      -9   5        $ GreavesRarityLabel��5�      $�� ��64   $
��25px��6?   $��11(�6M   �� 5�      -:   5        $ BootsRarityLabel��5�      $�� ��62   $
��25px��6=   $��11(�6K   �� 5�      -;   5        $ SpecialRarityLabel��5�      $�� ��64   $
��25px��6?   $��11(�6M   5�      �� 5�      -<   5        $ SkillsSkillPanel��5�      $��
0,50,100,0q�63   $��3��6G   $��0��6T   $��1��6d   5�      �� 5�      -=   5        $ SkillsLevelPanel��5�      $��
200,50,0,0q�63   $��3��6G   $��0��6T   $��1��6d   5�      �� 5�      ->   5        $ ProgressTitle��5�      $��0q�6+   $��	Slaying: ��67   $��	10,0,0,10q�6K   $
��20px��6^   $��12(�6l   $��4��6z   � 5�      -?   5         �Name$ ProgressBar��5�       K� ZIndex$ 3��6/    � Minimum$ 0Q�6A   $��0,20,0,0q�6M   	 � Maximum$		 100Q�6_   
 � Value$
 0Q�6m   $��4��6w   $��3��6�   �� 5�      -@   5        $ ExperienceTitle��5�      $��0q�6-   $��Experience: ��69   $��1,30,0,0q�6P   $
��15px��6b   $��10(�6p   $��2��6~   � 5�      -A   5        $ ExperienceBar��5�      $ 0Q�61   $��0,60,0,0q�6=   $		 100Q�6O   $
 0Q�6]   $��2��6g   �� 5�      -B   5        $ InventoryTitle��5�      $ 3��6,   $��0q�6>   $��Inventory Space: ��6J   $��	1,260,0,0q�6f   $
��18px��6y   $��10(�6�   $��3��6�   $��1��6�   � 5�      -C   5        $ InventoryBar��5�      $ 0Q�60   $��0,0,0,23q�6<   $
��15px��6N   $		 100Q�6\   $
 0Q�6j   $��4��6t   $��1��6�   �� 5�      $��1q�6   
���   �$��0��5�      $��3��6   $��1��6*   �� 5�      $��1q�6   
���   �$��2��5�      $��2��6   $��3��6*   �� 5�      $��1q�6   
���   �$��1��5�      $��2��6   $��3��6*   �� 5�      $��1q�6   
���   �$��0��5�      $��3��6   $��2��6*   �� 5�      $��1q�6   
���   �$��0��5�      $��1��6   $��2��6*   �� 5�      $��1q�6   
���   �$��0��5�      $��0��6   $��1��6*   �� 5�      $��1q�6   
���   �$��1��5�      $��0��6   $��2��6*   �� 5�      $��1q�6   
���   �$��2��5�      $��0��6   $��2��6*   �� 5�      $��1q�6   
���   �$��2��5�      $��0��6   $��2��6*   5�      5�      5�      