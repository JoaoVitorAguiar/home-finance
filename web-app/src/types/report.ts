export type PersonTotalsItem = {
    personId: number
    personName: string
    totalIncome: number
    totalExpense: number
    balance: number
}

export type TotalsByPersonResponse = {
    items: PersonTotalsItem[]
    totalIncome: number
    totalExpense: number
    balance: number
}

export type CategoryTotalsItem = {
    categoryId: number
    categoryDescription: string
    totalIncome: number
    totalExpense: number
}

export type TotalsByCategoryResponse = {
    items: CategoryTotalsItem[]
    totalIncome: number
    totalExpense: number
    balance: number
}