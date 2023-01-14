import random
board = [[" " for _ in range(3)] for _ in range(3)] 

print("\n\n")
def printBoard(board):
    for i in range(3):
        print("===============================")
        print("|         |         |         |")
        print(f"|    {board[i][0]}    |    {board[i][1]}    |    {board[i][2]}    |")
        print("|         |         |         |")
    print("===============================")   

def winCheck(board):
    # Check Row
    for i in range(3):
        if(board[i][0] == board[i][1] and board[i][0] == board[i][2]):
            return board[i][0]
    # Check Collum
    for i in range(3):
        if(board[0][i] == board[1][i] and board[0][i] == board[2][i]):
            return board[0][i]
    # Check Diagonal
    if(board[0][0] == board[1][1] and board[0][0] == board[2][2]):
        return board[0][0]
    if(board[0][2] == board[1][1] and board[0][2] == board[2][0]):
        return board[0][2]    
    return False

def aiAutoplay(ai,player):
    # Find Winning move --> Stop Losing move
    for a in range(2):
        if(a == 0):
            symCheck = player
        else:
            symCheck = ai
           
        # Row
        for i in range(3):
            if(board[i][0] == symCheck and board[i][0] == board[i][1] and board[i][2] == " "):
                return [i,2]
            if(board[i][0] == symCheck and board[i][0] == board[i][2] and board[i][1] == " "):
                return [i,1]
            if(board[i][1] == symCheck and board[i][1] == board[i][2] and board[i][0] == " "):
                return [i,0]
        # Collum
        for i in range(3):
            if(board[0][i] == symCheck and board[0][i] == board[1][i] and board[2][i] == " "):
                return [2,i]
            if(board[0][i] == symCheck and board[0][i] == board[2][i] and board[1][i] == " "):
                return [1,i]
            if(board[1][i] == symCheck and board[1][i] == board[2][i] and board[0][i] == " "):
                return [0,i]
        # Diagonal left
        if(board[1][1] == symCheck):
            if(board[0][0] == board[1][1] and board[2][2] == " "):
                return [2,2]
            if(board[0][0] == board[2][2] and board[1][1] == " "):
                return [1,1]
            if(board[1][1] == board[2][2] and board[0][0] == " "):
                return [0,0]
            # Diagonal right
            if(board[0][2] == board[1][1] and board[2][0] == " "):
                return [2,0]
            if(board[0][2] == board[2][0] and board[1][1] == " "):
                return [1,1]
            if(board[1][1] == board[2][0] and board[0][2] == " "):
                return [0,2]
    empty = []
    for i in range(3):
        for j in range(3):
            if(board[i][j] == " "):
                empty.append([i,j])
    return random.choice(empty)



