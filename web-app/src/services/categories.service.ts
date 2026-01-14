import { api } from "@/services/api"
import type { Category, CategoryPurpose } from "@/types/category"

export type CreateCategoryInput = {
    description: string
    purpose: CategoryPurpose
}

export class CategoriesService {
    static async getAll(): Promise<Category[]> {
        const { data } = await api.get<Category[]>("/categories")
        return data
    }

    static async create(input: CreateCategoryInput): Promise<void> {
        await api.post("/categories", input)
    }
}
