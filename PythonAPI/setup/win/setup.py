# This program is free software; you can redistribute it and/or
# modify it under the terms of the GNU General Public License
# as published by the Free Software Foundation; either version 2
# of the License, or (at your option) any later version.

# This program is distributed in the hope that it will be useful,
# but WITHOUT ANY WARRANTY; without even the implied warranty of
# MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
# GNU General Public License for more details.

# You should have received a copy of the GNU General Public License
# along with this program; if not, write to the Free Software Foundation,
# Inc., 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301, USA.

# The Original Code is Copyright (C) 2020 Voxell Technologies.
# All rights reserved.

import subprocess
import sys

def pipinstall(package):
  subprocess.check_call([sys.executable, "-m", "pip", "install", package])

def pipwininstall(package):
  subprocess.check_call([sys.executable, "-m", "pipwin", "install", package])

with open("../requirements.txt", "r") as f:
  packages = f.read().split("\n")
  for p in packages:
    pipinstall(p)

pipinstall("pipwin")

with open("./pipwinrequirements.txt", "r") as f:
  packages = f.read().split("\n")
  for p in packages:
    pipwininstall(p)

import nltk
nltk.download("punkt")