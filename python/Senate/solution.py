from string import ascii_letters
import heapq

def solve(senate):
    solution = []
    heapq.heapify(senate)
    next = heapq.heappop(senate)
    while next[0] < 0:
        heapq.heappush(senate, (next[0]+1, next[1]))
        solution.append(next[1])
        next = heapq.heappop(senate)

    pairs = ''
    if len(solution) % 2 != 0:
        pairs += solution.pop(0) + ' '
    while len(solution) > 0:
        pairs += solution.pop(0) + solution.pop(0) + ' '
    return pairs

def _buildSenate(problem):
    senate = []
    letter = 'A'
    for group in problem:
	    senate.append((group, letter))
	    letter=ascii_letters[ascii_letters.index(letter) + 1]
    return senate;

if __name__ == '__main__':
    import sys
    problem = [-int(i) for i in sys.argv[1].split(' ')]
    senate = _buildSenate(problem)
    solution = solve(senate)
    print(solution)
