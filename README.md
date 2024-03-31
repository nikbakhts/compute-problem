#### Initial steps

1. `git clone <URL> projectfolder`
2. `cd projectfolder`

#### Execution steps

__docker__
1. `docker build -t solution .`
2. `cat input | docker run -i --rm solution:latest 100 5000`
