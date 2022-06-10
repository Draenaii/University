class Country:
    """
    A Country has a name and a population size.
    People can be born and die, changing the population size.

    Attributes:
        name: str: the name of the country (required)
        population: int: how many people live there (required)
        BONUS: Must be at least 0.

    """

    def __init__(self, name, pop):
        """
        @param name: #TODO
        @param pop: #TODO
        Initialises a Country with a name and population.
        BONUS: If the population size given is less then 0, raises
            ValueError("Population must be at least 0")

        """
        if pop < 0:
            raise ValueError("Population must be at least 0")
        else:
            self.name = name
            self.population = pop

    def __repr__(self):
        """
        String representation of a country
        :return: str
        """
        return "{}, population {}".format(self.name, self.population)

    def births(self, birth):  # TODO: add parameter(s)
        """
        @param #TODO
        Adds the given number to the population.
        Prints "Population increased by x%", where x is
            how much the population grew by due to these births
            If the population was previously 0, #TODO
        """
        if self.population != 0:
            percenbirths = (birth * 100) / self.population
            self.population = self.population + birth
            print("Population increased by ", percenbirths,"%")
        else: 
            self.population = self.population + birth
            print("Since population was 0, it grew by an infinite percentage")

    def deaths(self, death):  # TODO: add parameter(s)
        """
        @param #TODO
        Removes the given number from the population, unless that takes the
        population below 0, in which case it reduces it to 0
        Prints "Population decreased by x%", where x is
            how much the population decreased by due to these deaths.
            If the population was previously 0, #TODO

        """
        if death > self.population:
            print("Population decreased by 100%")
        else:
            percendeath = (death * 100) / self.population
            self.population = self.population - death
            print("Population decreased by", percendeath,"%")