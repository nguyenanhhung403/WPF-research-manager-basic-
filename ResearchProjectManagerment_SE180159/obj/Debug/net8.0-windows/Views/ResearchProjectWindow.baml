   M S B A M L   `   `   `  ����^  ZResearchProjectManagerment_SE180159, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nulle7clr-namespace:ResearchProjectManagerment_SE180159.Views)ResearchProjectManagerment_SE180159.Views  5   	   E    ?ResearchProjectManagerment_SE180159.Views.ResearchProjectWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Ilocal7clr-namespace:ResearchProjectManagerment_SE180159.Views     5   	   -   5          � Title$/  )Research Project Management - Spring 2025��5	   	   $	��500��5
   	   $	��800��6   $��Tahoma)�5   	   $��13(�6   ���	#FFF5F5DC � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ txtUserInfo��5      $��0��5      $��12(�5      ���	#FF6B705C$��10q�5      $��Right=�5      � 5    
   $��1��6   $��
10,5,10,10q�6    � ColumnDefinitions 5!      �� 5"      $
��Auto �6#   �� 5#      $��* �6#   �� 5$      $
��Auto �6#   .+�5'      �� $��0��6   $��Search:��6$   $��Arial)�66   $��12(�6I   ���	#FF6B705C$��Center=�6n   �� 5(      -   5         ��Name$ 	txtSearch��5(   &   $��1��6   $��14��69   ���	#FFFFF8EB$	��5,0q�6\   �� 5)      -   5         ��Name$ 	btnSearch��5)   %   $��2��6   $��Search��68   $��5q�6I   ���	#FFB38B82
�������6   5*      &   System.Windows.Controls.DataGrid  5-   
   -   5          Name$ 
dgProjects��5.      $��2��5-      $
��10,0q�5/      ���	#FFFFF8EB   AutoGenerateColumns$ False��51      	   
IsReadOnly$
	 True��52      
   SelectionMode$
 Single=�53         AlternatingRowBackground �	#FFF0F0F0   GridLinesVisibility$	 All=�55         RowHeaderWidth$ 0Q�56         Columns 57      0  *System.Windows.Controls.DataGridTextColumn  58      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6O   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	ProjectId+6O     59      $ Project Title��6%   $ * 6]    6<   �� *ProjectTitle+6]     5:      $ Field��6%   $	 100 6V    64   �� *ResearchField+6V     5;      $
 Lead��6%   $	 100 6_    63   �� *LeadResearcher.FullName+6_     5<      $ 
Start Date��6%   $ 90 6v    69   �� *	StartDate+ �� StringFormat$ {0:dd/MM/yyyy}��6v     5=      $ End Date��6%   $ 90 6r    67   �� *	EndDate+$ {0:dd/MM/yyyy}��6r     5>      $ Budget��6%   $ 80 6a    65   �� *Budget+$ N2��6a      ColumnHeaderStyle 5@      �� 5A       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5B      ��  �� Property � �� �� Value �	#FFB38B8263   �� 5C       � ��
 �����63   �� 5D       � ��$ 5q�60   �� 5E       � ��$
 Bold"�63   5F      5H      �� 5K   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $
��0,10q�6X   .+�5L      �� -   5        $ btnAdd��5L      $��Add New��6%   $��5q�67   ���	#FFB38B82
�������$	��5,0q�6m   $��80��6z   6�   �� 5M      -   5        $ btnEdit��5M      $
��Edit��6&   $��5q�65   ���	#FFB38B82
�������$	��5,0q�6k   $��80��6x   6�   �� 5N      -   5        $ 	btnDelete��5N      $��Delete��6(   $��5q�69   ���	#FFB38B82
�������$	��5,0q�6o   $��80��6|   6�   5O      5P      5Q      