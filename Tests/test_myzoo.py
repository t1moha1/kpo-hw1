import unittest
import subprocess

class MyZooTests(unittest.TestCase):
    def run_app(self, inputs: str) -> str:
        process = subprocess.Popen(
            ["dotnet", "run", "--project", "../MyZoo.csproj"],
            stdin=subprocess.PIPE,
            stdout=subprocess.PIPE,
            stderr=subprocess.PIPE,
            text=True
        )
        stdout, stderr = process.communicate(inputs)
        return stdout + stderr

    def test_add_valid_rabbit(self):
        output = self.run_app("\n".join([
            "1", "Тимофей", "rabbit", "3", "9", "0"
        ]) + "\n")
        self.assertIn("признано здоровым", output)
        self.assertIn("принято в зоопарк", output)

    def test_add_invalid_animal_type(self):
        output = self.run_app("\n".join([
            "1", "Барсик", "cat", "2", "0"
        ]) + "\n")
        self.assertIn("неизвестный тип животного", output)

    def test_add_thing_and_display(self):
        output = self.run_app("\n".join([
            "5", "table", "Cтол Тимофея", "6", "0"
        ]) + "\n")
        self.assertIn("добавлена на баланс", output)
        self.assertIn("Вещи на балансе:", output)

    def test_total_food_calculation(self):
        output = self.run_app("\n".join([
            "1", "Коко", "monkey", "7", "8", "2", "0"
        ]) + "\n")
        self.assertIn("Всего требуется корма в день: 7 кг", output)

    def test_contact_zoo_candidates_output(self):
        output = self.run_app("\n".join([
            "1", "Тимофей", "rabbit", "1", "9", "3", "0"
        ]) + "\n")
        self.assertIn("подходящие для контактного зоопарка", output)
        self.assertIn("Тимофей", output)

    def test_invalid_menu_option(self):
        output = self.run_app("999\n0\n")
        self.assertIn("Неизвестный пункт", output)

if __name__ == "__main__":
    unittest.main()