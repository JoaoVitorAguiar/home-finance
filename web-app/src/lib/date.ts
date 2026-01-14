export function birthDateFromAge(age: number): string {
    const today = new Date()
    const year = today.getFullYear() - age

    const birthDate = new Date(year, today.getMonth(), today.getDate())

    return birthDate.toISOString().split("T")[0] // yyyy-mm-dd
}