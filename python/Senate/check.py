from string import ascii_letters

def checkSolution(problem, solution):
    senate = _buildSenate(problem)

    for step in solution:
        _applyStep(senate, step.strip('\n'))
        if _checkStep(senate) is not True:
            return False, senate

    if sum(senate.values()) == 0:
        return True, None
    else:
        return False, senate

def _buildSenate(problem):
    senate = {}
    letter = 'A'
    for group in problem:
        senate[letter] = group
        letter=ascii_letters[ascii_letters.index(letter) + 1]
    return senate;

def _checkStep(senate):
   return max(senate.values()) <= sum(senate.values()) / 2

def _applyStep(senate, step):
    for i in step:
        senate[i] -= 1;

if __name__ == '__main__':
    import sys

    problem = [int(i) for i in sys.argv[1].split(' ')]
    if len(sys.argv) == 3:
        solution = sys.argv[2].split(' ')
    else:
        solution = sys.stdin
    res, senate = checkSolution(problem, solution)
    
    if res:
        print('OK')
    else:
        print(f'FAIL', senate)
