# Consordle
Consordle - Wordle but for the Windows console. Available in Czech and English.

## How to use
### To start in Czech...
...type `consordle -cz` in the console.
### To start in English...
...type `consordle -en` or `consordle` in the console.

## Game rules
The point of the game is to guess the five-letter word in just 6 guesses with color clues.
### hoopy
- the H is green - it's in the correct position
- the OO is yellow - it's in the word, but not in the correct position
  - note: if the letter's in the word, it might appear multiple times as yellow even though the letter in the final word might be there once
- the PS is gray - it's not in the word
### loops
- the LOO is yellow
  - we're getting somewhere - great!
- the PS is gray
### world
- the W is gray
- the O is yellow
- the R is gray
- the L is green - nice.
- the D is gray
### hello
- the HELLO is fully green - I won! And I guessed it in 4/6 guesses.
