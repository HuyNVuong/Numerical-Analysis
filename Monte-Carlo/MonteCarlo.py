import math
import random
from typing import List

import matplotlib.pyplot as plt
import numpy as np


def monte_carlo(f, x1: int, y1: int, x2: int, y2 : int, 
                n_points: int = 1000) -> (List[float], List[float], 
                List[float], float):
  xs = generate_random_numbers(x1, x2, n_points)
  ys = generate_random_numbers(y1, y2, n_points)
  ys_true = [f(x) for x in xs]
  ys_inbound = [abs(y) <= y_true for y, y_true in zip(ys, ys_true)]  
  count = np.count_nonzero(ys_inbound)
  area = count / n_points * 8

  return xs, ys, ys_true, area

def plot_graph(xs: List[float], 
               ys: List[float], 
               ys_true: List[float]) -> None:
  plt.scatter(xs, ys)
  plt.scatter(xs, ys_true, color='green')
  plt.scatter(xs, [-y for y in ys_true], color='green')
  plt.show()

def generate_random_numbers(a, b, n: int) -> List[int]:
  xs = [random.uniform(a, b) for i in range(n)]
  return xs

def f(x):
  return math.sqrt(1 - x ** 2 / 4)

def ellipse_area(a: int, b: int) -> float:
  return math.pi / 4 * a * b

xs, ys, ys_true, monte_carlo_area = monte_carlo(f, -2, -1, 2, 1, n_points=1000)
actual_area = ellipse_area(4, 2)
print(monte_carlo_area)
print(actual_area)
plot_graph(xs, ys, ys_true)
