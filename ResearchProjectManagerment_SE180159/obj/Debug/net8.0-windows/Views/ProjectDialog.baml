   M S B A M L   `   `   `  ����^  ZResearchProjectManagerment_SE180159, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:ResearchProjectManagerment_SE180159.Views)ResearchProjectManagerment_SE180159.Views  5   	   =    7ResearchProjectManagerment_SE180159.Views.ProjectDialog   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:ResearchProjectManagerment_SE180159.Views     5   	     � Title$  Project Details��5	   	   $	��450��5
   	   $	��500��6   $��Tahoma)�5   	   $��13(�6   ���	#FFF5F5DC � WindowStartupLocation$ CenterOwner=�5   	    � 
ResizeMode$ NoResize=�5   	   .��5      � $��10q�6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6   $��Project Information��5      $��Arial)�5      $��18(�6'   ���	#FF6B705C$��Center=�5      $��0,0,0,15q�5      �� 5   
   $��1��6   $
��Auto=�6$   .��5      �  5      �� 5       $
��Auto �6$   �� 5!      $
��Auto �6$   �� 5"      $
��Auto �6$   �� 5#      $
��Auto �6$   �� 5$      $
��Auto �6$   �� 5%      $
��Auto �6$    � ColumnDefinitions 5'      �� 5(      $	��130 �6'   �� 5)      $��* �6'   .+�5-      �� $��0��6   $��0��6%   $��Project Title:��5.      $��Arial)�5/      $��12(�6+   ���	#FF6B705C$��Center=�51      $	��0,5q�52      �� 53      -   5         ��Name$ txtProjectTitle��54      $��0��53      $��1��6'   $��30��55      ���	#FFFFF8EB$	��0,5q�57      �� 5:      $��1��6   $��0��6%   $��Research Field:��5;      $��Arial)�5<      $��12(�6+   ���	#FF6B705C$��Center=�5>      $	��0,5q�5?      �� 5@      -   5        $ txtResearchField��5A      $��1��5@      $��1��6'   $��30��5B      ���	#FFFFF8EB$	��0,5q�5D      �� 5G      $��2��6   $��0��6%   $��Lead Researcher:��5H      $��Arial)�5I      $��12(�6+   ���	#FF6B705C$��Center=�5K      $	��0,5q�5L      �� 5M      -   5         ��Name$ cmbLeadResearcher��5N      $��2��5M      $��1��6(   $��14��5O      ���	#FFFFF8EB �� DisplayMemberPath$ FullName��5Q       �� SelectedValuePath$ ResearcherId��5R      $	��0,5q�5S      �� 5V      $��3��6   $��0��6%   $��Start Date:��5W      $��Arial)�5X      $��12(�6+   ���	#FF6B705C$��Center=�5Z      $	��0,5q�5[      (  "System.Windows.Controls.DatePicker  5\      -   5        	  Name$	 dpStartDate��5]      $��3��5\      $��1��6*   $��30��5^      ���	#FFFFF8EB$	��0,5q�5`      �� 5c      $��4��6   $��0��6%   $��	End Date:��5d      $��Arial)�5e      $��12(�6+   ���	#FF6B705C$��Center=�5g      $	��0,5q�5h        5i      -   5        $	 	dpEndDate��5j      $��4��5i      $��1��6*   $��30��5k      ���	#FFFFF8EB$	��0,5q�5m      �� 5p      $��5��6   $��0��6%   $��Budget:��5q      $��Arial)�5r      $��12(�6+   ���	#FF6B705C$��Center=�5t      $	��0,5q�5u      �� 5v      -   5        $ 	txtBudget��5w      $��5��5v      $��1��6'   $��30��5x      ���	#FFFFF8EB$	��0,5q�5z      5{      5|      �� 5   
   -   5        
 ��Name$
 txtErrorMessage��5�      $��1��5      
���  ��$��12(�5�      $
��Wrap=�5�      $��Bottom=�5�      $
��0,10q�5�      �� 5�   
   $��2��6    �� Orientation$ 
Horizontal=�5�      $��Center=�5�      $��0,15,0,0q�5�      .+�5�      �� -   5         ��Name$ btnSave��5�      $
��Save��5�      $��5q�5�      ���	#FFB38B82
�������$��80��5�      $	��5,0q�5�      5�      �� 5�      -	   5        $ 	btnCancel��5�      $��Cancel��5�      $��5q�5�      ���	#FFB38B82
�������$��80��5�      $	��5,0q�5�      5�      5�      5�      5�      